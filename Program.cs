using NetsisRestOrnekleri.Model;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;

namespace NetsisRestOrnekleri
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://netsisrestserver:7070/api/v2/ItemSlips";
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

            restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(GetirToken(), "Bearer");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(siparis);

            var httpResult = restClient.Execute(request);

        }

        public static string GetirToken()
        {
            var token = "";
            var url = "http://netsisrestserver:7070/api/v2/token";
            var restClient = new RestClient(url);
            var request = new RestRequest
            {
                Method = Method.Post,
                RequestFormat = DataFormat.Json,
            };

            var body = "grant_type=password&branchcode=netsissubekodu&password=netsissifre&username=netsiskullanici&dbname=TEST&dbuser=TEMELSET&dbpassword=&dbtype=0";
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(body);

            var httpResult = restClient.Execute<TokenSonuc>(request);

            return httpResult.Data.access_token;
        }

    }
}
