using System;

namespace TesteWebAPI.Services.Models
{
    public class BalancoComercialPorPais
    {
        public int AnoBase { get; set; }
        public string Pais { get; set; }
        public string Sigla { get; set; }
        public double ValorExportado { get; set; }
        public double ValorImportado { get; set; }
    }

    public class BalancoComercialPorContinente
    {
        public int AnoBase { get; set; }
        public string Continente { get; set; }
        public double ValorExportado { get; set; }
        public double ValorImportado { get; set; }
    }
}