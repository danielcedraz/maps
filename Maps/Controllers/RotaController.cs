using System;
using System.Linq;
using Maps.DBO;
using Maps.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maps.Controllers
{
    
    /// <summary>
    /// Controller responsável por suprir o processo de roteamento.
    /// </summary>
    public class RotaController : Controller
    {
        /// <summary>
        /// Método responsável por salvar os dados de rota, ponto e parada no banco de dados.
        /// </summary>
        /// <param name="Rota">Objeto do tipo RotaModel que deve conter os dados da rota.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SalvarRota(RotaModel Rota)
        {
            try
            {
                //Verifica se o usuário preencheu a origem.
                if (String.IsNullOrWhiteSpace(Rota.Origem))
                    throw new Exception("A origem não pode ser vazia.");

                //Verifica se o usuário preencheu o destino.
                if (String.IsNullOrWhiteSpace(Rota.Destino))
                    throw new Exception("O destino não pode ser vazio.");

                using (DBContextModel dbContext = new DBContextModel())
                {
                    Ponto origem = dbContext.Pontos.Where(p => p.Nome.ToLower() == Rota.Origem.ToLower()).FirstOrDefault();

                    if (origem == null)
                    {
                        origem = new Ponto() { Nome = Rota.Origem };

                        dbContext.Pontos.Add(origem);
                    }

                    Ponto destino = dbContext.Pontos.Where(p => p.Nome.ToLower() == Rota.Destino.ToLower()).FirstOrDefault();

                    if (destino == null)
                    {
                        destino = new Ponto() { Nome = Rota.Destino };

                        dbContext.Pontos.Add(destino);
                    }

                    Rota rota = new Rota()
                    {
                        Origem = origem,
                        Destino = destino
                    };

                    int i = 0;

                    if (Rota.Paradas != null)
                        foreach (var item in Rota.Paradas)
                        {
                            Ponto ponto = dbContext.Pontos.Where(p => p.Nome.ToLower() == item.ToLower()).FirstOrDefault();

                            if (ponto == null)
                            {
                                ponto = new Ponto() { Nome = item };

                                dbContext.Pontos.Add(ponto);
                            }

                            Parada parada = new Parada() 
                            { 
                                Rota = rota,
                                Ponto = ponto,
                                Ordem = i
                            };

                            dbContext.Add(parada);

                            i++;
                        }

                    dbContext.Add(rota);

                    dbContext.SaveChanges();

                    return Json(new ResultModel() { Erro = false });
                }
            }
            catch (Exception e)
            {
                return Json(new ResultModel() { Erro = true, Mensagem = e.Message });
            }
        }

        /// <summary>
        /// Método reponsável por obter os pontos já utilizados em rotas anteriores.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObterPontos()
        {
            try
            {
                using (DBContextModel dbContext = new DBContextModel())
                {
                    var pontos = dbContext.Pontos.ToList();

                    return Json(pontos);
                }
            } catch (Exception e)
            {
                return Json(new ResultModel() { Erro = true, Mensagem = e.Message });
            }
        }
    }
}
