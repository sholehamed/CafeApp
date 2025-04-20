using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using CafeApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CafeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITablesService _service;

        public TablesController(IApplicationUnit applicationUnit)
        {
            _service = applicationUnit.Tables;
        }

        // GET: api/<TablesController>
        [HttpGet]
        public async Task<ActionResult<PagedList<TableDto>>> Get([FromQuery]ListTableParameter parameter)
        {
            try
            {
                var res = await _service.GetPaged(parameter.GetSpecifications(), parameter);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("sync")]
        public async Task<ActionResult<ICollection<ProductCategoryEntity>>> SyncCategories()
        {
            try
            {
                var res = await _service.GetAllForSync();
                return Ok(res);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("apply")]
        public async Task<IActionResult> Apply()
        {
            try
            {
                await _service.Apply();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPost("writesync")]
        public async Task<IActionResult> WriteSync(TableEntity entity)
        {
            try
            {
                await _service.WriteSync(entity);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("dashboardTables")]
        public async Task<ActionResult<ICollection<DashboardTableModel>>> GetDashboardTables()
        {
            try
            {
                var res = await _service.GetDashboardTables();
                return Ok(res);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        // GET api/<TablesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDto>> Get(Guid id)
        {
            try
            {
                var res = _service.GetBy(new GetTableParameter(id).GetSpecifications());
                return Ok(await Task.FromResult(res));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // POST api/<TablesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTableParameter value)
        {
            try
            {
                await _service.CreateAsync(value);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<TablesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTableParameter value)
        {
            try
            {
                await _service.UpdateAsync(value);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
