using NUnit.Framework;
using Maps;
using Maps.Controllers;
using Maps.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Maps.Testes
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SalvarRotaTest()
        {
            try
            {
                RotaModel rota = new RotaModel()
                {
                    Origem = "Feira de Santana",
                    Destino = "Salvador",
                    Paradas = new List<string>() { "Camaçari" }
                };

                RotaController controller = new RotaController();
                ResultModel result = (ResultModel)controller.SalvarRota(rota).Value;

                if (result.Erro)
                    throw new Exception(result.Mensagem);
                
                Assert.Pass();
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }            
        }
    }
}