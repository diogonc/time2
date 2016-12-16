using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TimeDois.Extensoes
{
    public static class Extensoes
    {
        public static string RemoverMascara(this string numeroComMascara)
        {
            return string.IsNullOrWhiteSpace(numeroComMascara) ? string.Empty : Regex.Replace(numeroComMascara, @"[^\d]", "");
        }

        public static string FormatarCnpj(this string cnpj)
        {
            return string.IsNullOrWhiteSpace(cnpj) ? string.Empty : Convert.ToInt64(RemoverMascara(cnpj)).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatarCpf(this string cpf)
        {
            return string.IsNullOrWhiteSpace(cpf) ? string.Empty : Convert.ToInt64(RemoverMascara(cpf)).ToString(@"000\.000\.000-00");
        }

        public static string FormatarCep(this string cep)
        {
            return string.IsNullOrWhiteSpace(cep) ? string.Empty : Convert.ToInt64(RemoverMascara(cep)).ToString(@"00000-000");
        }

        public static bool EhNumeroInteiro(this string texto)
        {
            long numero;
            return Int64.TryParse(texto, out numero);
        }

        public static bool EhData(this string texto, string formatoDeData)
        {
            DateTime dataConvertida;
            return DateTime.TryParseExact(texto, "yyyyMMdd", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dataConvertida);
        }

        public static string ComZeroAEsquerda(this string valor, int quantidade)
        {
            return valor.PadLeft(quantidade, '0');
        }

        public static string ComEspacoADireita(this string valor, int quantidade)
        {
            var novoValor = valor;

            if (string.IsNullOrWhiteSpace(novoValor))
                novoValor = string.Empty;

            return novoValor.PadRight(quantidade, ' ');
        }

        public static bool IsNotEmpty(this string valor)
        {
            return !string.IsNullOrWhiteSpace(valor);
        }

        public static string Concatenar(this string valor, string valorASerConcatenado)
        {
            return string.Concat(valor, valorASerConcatenado);
        }

        public static string RemoverAcentos(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            var bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        public static bool EstaEm(this int numero, params int[] listaDeNumeros)
        {
            if (listaDeNumeros == null) return false;

            return listaDeNumeros.Contains(numero);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            var collection = list as ICollection<T>;
            if (collection != null) return collection.Count == 0;

            return !list.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var element in source)
                action(element);
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            if (chunksize <= 0) throw new ArgumentException("Chunk size must be greater than zero.", nameof(chunksize));
            while (source.Any())
            {
                yield return source.Take(chunksize).ToList<T>();
                source = source.Skip(chunksize);
            }
        }

        public static string ToDescription(this Enum en, bool toUpper = true)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length <= 0) return en.ToString();
            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : en.ToString();
            return toUpper ? description.ToUpper() : description;
        }

        public static IList<T> ToList<T>(this T theEnum) where T : struct, IComparable, IFormattable, IConvertible
        {
            return Enumerable.ToList(Enum.GetValues(theEnum.GetType()).Cast<T>());
        }

        public static DateTime ColocarNoPrimeiroDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        public static DateTime ColocarDataNoUltimoDiaComercialDoMes(this DateTime data)
        {
            var diaComercialDoMes = data.Month == 2 ? (DateTime.IsLeapYear(data.Year) ? 29 : 28) : 30;
            return new DateTime(data.Year, data.Month, diaComercialDoMes);
        }

        public static DateTime PosicionarNoProximoMesNoDiaBase(this DateTime data, int dia)
        {
            var umMesAPartirDaDataInicial = data.AddMonths(1);

            if (umMesAPartirDaDataInicial.Day == dia)
                return umMesAPartirDaDataInicial;

            if (umMesAPartirDaDataInicial.Day == 1)
                umMesAPartirDaDataInicial = umMesAPartirDaDataInicial.AddMonths(-1);

            umMesAPartirDaDataInicial = umMesAPartirDaDataInicial.ColocarDataNoDiaOuNoProximoDiaValido(dia);
            return umMesAPartirDaDataInicial;
        }

        public static DateTime ColocarDataNoDiaOuNoProximoDiaValido(this DateTime data, int dia)
        {
            try
            {
                return new DateTime(data.Year, data.Month, dia);
            }
            catch (Exception)
            {
                return new DateTime(data.Year, data.Month + 1, 1);
            }
        }

        public static DateTime PrimeiroDiaDoTrimestre(this DateTime data)
        {
            var mesDoTrimestre = ((data.Month - 1) / 3) * 3 + 1;

            return new DateTime(data.Year, mesDoTrimestre, 1);
        }

        public static bool NoPeriodo(this DateTime dataAComparar, DateTime? dataInicial, DateTime? dataFinal)
        {
            var comparacaoInferior = true;
            var comparacaoSuperior = true;

            if (dataInicial.HasValue)
                comparacaoInferior = (dataAComparar >= dataInicial.Value);

            if (dataFinal.HasValue)
                comparacaoSuperior = (dataAComparar <= dataFinal.Value);

            return (comparacaoInferior && comparacaoSuperior);
        }

        public static bool DataValida(this DateTime date)
        {
            var dataMinima = new DateTime(1900, 01, 01);
            return date > dataMinima;
        }

        public static bool CompararMesEAno(this DateTime date, DateTime dataASerComparada)
        {
            var date1 = date.ColocarNoPrimeiroDiaDoMes();
            var date2 = dataASerComparada.ColocarNoPrimeiroDiaDoMes();

            return date1 == date2;
        }

        public static DateTime ColocarNoPrimeiroDiaDoMesRetrasado(this DateTime data)
        {
            return data.AddMonths(-2).ColocarNoPrimeiroDiaDoMes();
        }

        public static DateTime ColocarNoMes(this DateTime data, int mes)
        {
            return new DateTime(data.Year, mes, data.Day);
        }

        public static DateTime ColocarDataNoProximoMes(this DateTime data)
        {
            return data.AddMonths(1);
        }

        public static DateTime ColocarNoUltimoDiaDoMes(this DateTime data)
        {
            var ultimoDiaDoMes = DateTime.DaysInMonth(data.Year, data.Month);

            return new DateTime(data.Year, data.Month, ultimoDiaDoMes);
        }

        public static int DiferencaEmDias(this DateTime data, DateTime dataFinal)
        {
            return (int)(dataFinal - data).TotalDays;
        }

        public static string FormatarDiaMesAno(this DateTime data)
        {
            return data != DateTime.MinValue ? data.ToString("dd/MM/yyyy") : "";
        }

        public static string FormatarDataEHora(this DateTime data)
        {
            return data.ToString("dd/MM/yyyy HH:mm");
        }

        public static string EscreverData(this DateTime data)
        {
            var culture = new CultureInfo("pt-BR");
            var formataData = culture.DateTimeFormat;

            var mes = culture.TextInfo.ToTitleCase(formataData.GetMonthName(data.Month));

            return string.Format("{0} de {1} de {2}", data.Day, mes, data.Year);
        }

        public static string EscreverMes(this DateTime data, bool toUpper = false)
        {
            var culture = new CultureInfo("pt-BR");
            var formataData = culture.DateTimeFormat;

            var mes = culture.TextInfo.ToTitleCase(formataData.GetMonthName(data.Month));

            return toUpper ? mes.ToUpper() : mes;
        }

        public static string EscreverMesEAno(this DateTime data, bool toUpper = false)
        {
            var culture = new CultureInfo("pt-BR");
            var formataData = culture.DateTimeFormat;

            var mes = culture.TextInfo.ToTitleCase(formataData.GetMonthName(data.Month));

            return toUpper ? string.Format("{0}/{1}", mes.ToUpper(), data.Year) : string.Format("{0}/{1}", mes, data.Year);
        }

        public static DateTime MesPassado(this DateTime data)
        {
            return data.AddMonths(-1);
        }


        public static DateTime ProximoAniversario(this DateTime data, int mesBase)
        {
            var ano = (data.Month >= mesBase) ? data.Year + 1 : data.Year;

            return new DateTime(ano, mesBase, data.Day);
        }

        public static decimal Truncar(this decimal valor, int numeroDeCasasDecimais)
        {
            if (numeroDeCasasDecimais < 0)
                throw new InvalidOperationException("Número de casas decimais deve ser igual/maior a zero.");

            var numero = (decimal)Math.Pow(10, numeroDeCasasDecimais);

            var novoValor = valor * numero;
            var valorTruncado = Math.Truncate(novoValor);
            return valorTruncado / numero;
        }

        public static decimal ParaUmQuandoZero(this decimal valor)
        {
            return (valor == 0m ? 1 : valor);
        }

        public static decimal AplicarIndice(this decimal valor, decimal indice)
        {
            return valor * indice;
        }

        public static decimal Elevar(this decimal valor, decimal expoente)
        {
            return (decimal)Math.Pow((double)valor, (double)expoente);
        }

        public static decimal ObterValorPercentual(this decimal valor, decimal percentual)
        {
            return (valor * percentual) / 100;
        }

        public static decimal ObterPercentual(this decimal valorBase, decimal valor)
        {
            return (valorBase * 100) / valor;
        }

        public static decimal Arredondar(this decimal valor, int numeroDeCasasDecimais)
        {
            return decimal.Round(valor, numeroDeCasasDecimais);
        }

        public static decimal Teto(this decimal valor, int numeroDeCasasDecimais)
        {
            var potencia = 10m;
            potencia = potencia.Elevar(numeroDeCasasDecimais);

            return Math.Ceiling(valor * potencia) / potencia;
        }

        public static string ComZeroAEsquerda(this int valor, int quantidade)
        {
            return valor.ToString().PadLeft(quantidade, '0');
        }

        public static string ComZeroAEsquerda(this Int64 valor, int quantidade)
        {
            return valor.ToString().PadLeft(quantidade, '0');
        }

        public static string ComZeroAEsquerda(this decimal valor, int quantidade)
        {
            return valor.ToString().PadLeft(quantidade, '0');
        }

        public static decimal Acumular(this IEnumerable<decimal> valores)
        {
            decimal resultado = 1;

            if (valores != null)
                resultado = valores.Aggregate(resultado, (current, indice) => current * indice);

            return resultado;
        }

        public static string RemoverPontuacaoEManterCasasDecimais(this decimal valor, int casasDecimais)
        {
            var multiplicador = (int)Math.Pow(10, casasDecimais);

            return (valor * multiplicador).ToString("0");
        }

        public static string Formatar(this decimal valor)
        {
            return String.Format("{0:C}", valor);
        }

        public static string FormatarMonetarioOuVazio(this decimal valor)
        {
            return valor > 0 ? valor.Formatar() : "";
        }

        public static string FormatarMonetarioOuZero(this decimal valor)
        {
            return valor != 0 ? valor.Formatar() : "R$ 0,00";
        }
        
        public static string FormatarComPercentual(this decimal valor)
        {
            var valorArredondado = valor.Arredondar(2);
            return string.Format("{0}%", valorArredondado.FormatarComDuasCasasDecimais());
        }

        public static string FormatarComMetros(this decimal valor)
        {
            return valor.FormatarComQuatroCasasDecimais().Concatenar(" m");
        }

        public static string FormatarComMetrosQuadrados(this decimal valor)
        {
            return valor.FormatarComQuatroCasasDecimais().Concatenar(" m²");
        }

        public static string FormatarComDuasCasasDecimais(this decimal valor)
        {
            return string.Format("{0:0.00}", valor);
        }

        public static string FormatarComQuatroCasasDecimais(this decimal valor)
        {
            return string.Format("{0:0.0000}", valor);
        }

        public static bool IgualComMargemDeErro(this decimal valor, decimal outroValor, decimal margemDeErro)
        {
            return outroValor - margemDeErro <= valor && valor <= outroValor + margemDeErro;
        }
    }
}