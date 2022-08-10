using NetsisRestOrnekleri.Model;
using RestSharp;
using System;
using System.Collections.Generic;

namespace NetsisRestOrnekleri
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://restapiurl";
            var restClient = new RestClient(url);

            var siparis = new Dokuman();
            siparis.FatUst = new DokumanBaslik
            {
                ACIKLAMA = "aciklama",
                CariKod = "cariKod",
                EKACK1 = "KOD1",
                FATIRS_NO = "faturano",
                KDV_DAHILMI = true,
                KOD1 = "KOD1",
                Proje_Kodu = "cariKod",
                Sube_Kodu = 0,
                Tarih = DateTime.Now.ToString(),
                Tip = 7,
                TIPI = 2,
            };

            siparis.Kalems = new List<DokumanSatir>();
            var satir = new DokumanSatir
            {
                DEPO_KODU = "0",
                StokKodu = "stokkodu",
            };

            siparis.Kalems.Add(satir);

            var request = new RestRequest
            {
                Method = Method.Post,
                RequestFormat = DataFormat.Json,
            };

            request.AddParameter("application/json", siparis, ParameterType.RequestBody);

            var httpResult = restClient.Execute(request);

        }
    }
}
