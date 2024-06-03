using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SIG_VETERINARIA.Abstractions.IApplication;
using SIG_VETERINARIA.DTOs.Common;
using SIG_VETERINARIA.DTOs.Recetas;

namespace SIG_VETERINARIA.API.Controllers
{
    [ApiController]
    [Route("/api/recetas")]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetasApplication _recetasApplication;

        public RecetasController(IRecetasApplication recetasApplication)
        {
            _recetasApplication = recetasApplication;
        }

        [HttpPost]
        [Route("list")]
        public async Task<ActionResult> GetAll([FromBody] RecetasListRequestDTO request)
        {
            try
            {
                var res = await this._recetasApplication.GetAllRecetas(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] RecetasCreateRequestDTO request)
        {
            try
            {
                var res = await this._recetasApplication.CreateReceta(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                var res = await this._recetasApplication.DeleteReceta(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("pdf")]
        public async Task<ActionResult> GeneratePDF(DeleteDto request)
        {
            try
            {
                var res = await this._recetasApplication.DetailReceta(request);

                var doc = Document.Create(document =>
                {
                    document.Page(page =>
                    {
                        page.Margin(30);
                        page.Header().ShowOnce().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().AlignCenter().Text("Receta").Bold().FontSize(20).FontColor("#017bbe");
                            });
                        });
                        page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Text(text =>
                                {
                                    text.Span("Paciente: ").SemiBold().FontSize(12).FontColor("#017bbe");
                                    text.Span(res.Item.paciente).SemiBold().FontSize(12).FontColor("#017bbe");

                                });
                            });
                            column.Item().PaddingVertical(10);
                            column.Item().Column(col =>
                            {
                                col.Item().Text("Descripcion").FontColor("#017bbe");
                                col.Item().PaddingVertical(2);
                                col.Item().Border(0.5f).BorderColor("#017bbe").Padding(10).Text(res.Item.description).FontSize(10);
                            });
                            column.Item().PaddingVertical(10);
                            column.Item().Column(col =>
                            {
                                col.Item().Text("Indicaciones").FontColor("#017bbe");
                                col.Item().PaddingVertical(2);
                                col.Item().Border(0.5f).BorderColor("#017bbe").Padding(10).Text(res.Item.indicaciones).FontSize(10);
                            });
                        });

                        page.Footer()
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span("Pagina ").FontSize(10);
                            text.CurrentPageNumber().FontSize(10);
                            text.Span(" de ").FontSize(10);
                            text.TotalPages().FontSize(10);
                        });
                    });
                }).GeneratePdf();
                Stream stream = new MemoryStream(doc);
                return File(stream, "application/pdf", "receta.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
