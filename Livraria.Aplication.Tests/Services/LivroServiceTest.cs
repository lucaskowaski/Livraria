using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Livraria.Application.Interfaces;
using Livraria.Application.Services;
using Livraria.Application.ViewModels;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using NSubstitute;
using NUnit.Framework;

namespace Livraria.Aplication.Tests.Services
{
    class LivroServiceTest
    {
        private ILivroService LivroService;
        private ILivroRepository LivroRepository;

        private Livro LivroComId;
        private Livro LivroSemId;
        private IQueryable<Livro> Livros;
        private LivroViewModel LivroVmSemId;
        private LivroViewModel LivroVmComId;
        private LivroViewModel LivroVmInvalida;
        private List<LivroViewModel> LivrosVm;

        [SetUp]
        public void Setup()
        {
            GerarDadosParaTeste();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Livro, LivroViewModel>();
                cfg.CreateMap<LivroViewModel, Livro>();
            });
            LivroRepository = Substitute.For<ILivroRepository>();
            LivroRepository.Get(LivroComId.Id).Returns(LivroComId);
            LivroRepository.GetAll().Returns(Livros);
            LivroService = new LivroService(configuration.CreateMapper(), LivroRepository);
        }

        [Test]
        public void Quando_adicionar_livro_deve_mapear_corretamente()
        {
            LivroRepository.When(l => l.Add(Arg.Any<Livro>())).Do(x =>
            {
                x.Arg<Livro>().Should().BeEquivalentTo(LivroSemId);
            });
            LivroService.Add(LivroVmSemId);
        }

        [Test]
        public void Quando_adicionar_livro_deve_lancar_execao_se_model_for_invalida()
        {
            Assert.Throws<ValidationException>(() => LivroService.Add(LivroVmInvalida));
        }

        [Test]
        public void Quando_alterar_livro_deve_mapear_corretamente()
        {
            LivroRepository.When(l => l.Update(Arg.Any<Livro>())).Do(x =>
            {
                x.Arg<Livro>().Should().BeEquivalentTo(LivroComId);
            });
            LivroService.Add(LivroVmComId);
        }

        [Test]
        public void Quando_alterar_deve_lancar_execao_se_model_for_invalida()
        {
            Assert.Throws<ValidationException>(() => LivroService.Update(LivroVmInvalida));
        }

        [Test]
        public void Quando_obter_um_livro_por_id_deve_mapear_corretamente()
        {
            LivroService.Get(LivroComId.Id).Should().BeEquivalentTo(LivroVmComId);
        }

        [Test]
        public void Quando_obter_um_livro_por_id_deve_lancar_erro_se_o_parametro_estiver_incorreto()
        {
            Assert.Throws<ArgumentException>(() => LivroService.Get(0));
        }

        [Test]
        public void Quando_obter_todos_os_livros_deve_mapear_corretamente()
        {
            LivroService.GetAll().Should().BeEquivalentTo(LivrosVm);
        }

        [Test]
        public void Quando_deletar_livro_deve_lancar_execao_se_id_for_invalido()
        {
            Assert.Throws<ArgumentException>(() => LivroService.Remove(0));
        }

        [Test]
        public void Quando_deletar_livro_deve_passar_o_id_corretamente()
        {
            int id = 1;
            LivroRepository.When(l => l.Remove(Arg.Any<int>())).Do(x =>
            {
                x.Arg<int>().Should().Be(id);
            });
            LivroService.Remove(id);
        }

        private void GerarDadosParaTeste()
        {
            LivroComId = LivroFakes.livros.ToList().First();
            LivroSemId = new Livro()
            {
                Titulo = LivroComId.Titulo,
                Autor = LivroComId.Autor,
                Idioma = LivroComId.Idioma,
                AnoPublicacao = LivroComId.AnoPublicacao,
                NumeroPaginas = LivroComId.NumeroPaginas
            };
            LivroVmComId = new LivroViewModel()
            {
                Id = LivroComId.Id,
                Titulo = LivroComId.Titulo,
                Autor = LivroComId.Autor,
                Idioma = LivroComId.Idioma,
                AnoPublicacao = LivroComId.AnoPublicacao,
                NumeroPaginas = LivroComId.NumeroPaginas
            };
            LivroVmSemId = new LivroViewModel()
            {
                Id = LivroSemId.Id,
                Titulo = LivroSemId.Titulo,
                Autor = LivroSemId.Autor,
                Idioma = LivroSemId.Idioma,
                AnoPublicacao = LivroSemId.AnoPublicacao,
                NumeroPaginas = LivroSemId.NumeroPaginas
            };
            LivroVmInvalida = LivroFakes.livroVmInvalida;
            Livros = LivroFakes.livros;
            LivrosVm = LivroFakes.livros.Select(l => new LivroViewModel()
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Autor = l.Autor,
                Idioma = l.Idioma,
                AnoPublicacao = l.AnoPublicacao,
                NumeroPaginas = l.NumeroPaginas
            }).ToList();
        }
    }
}
