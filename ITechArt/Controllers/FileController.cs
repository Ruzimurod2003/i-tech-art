using ITechArt.Data;
using ITechArt.Functions;
using ITechArt.Models.ForDatabase;
using Microsoft.AspNetCore.Mvc;

namespace ITechArt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IFileXLSX fileXLSX;
        private readonly IFileCSV fileCSV;
        private readonly IFileXML fileXML;

        public FileController(ApplicationContext context, IFileXLSX _fileXLSX, IFileCSV _fileCSV, IFileXML _fileXML)
        {
            _context = context;
            fileXLSX = _fileXLSX;
            fileCSV = _fileCSV;
            fileXML = _fileXML;
        }

        // GET: api/File/save_xlsx
        [HttpGet("save_xlsx")]
        public async Task<string> SaveDatabaseXLSX()
        {
            try
            {
                List<Person> people = fileXLSX.GetValue();
                foreach (var person in people)
                {
                    _context.Add(person);
                }
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        // GET: api/File/save_csv
        [HttpGet("save_csv")]
        public async Task<string> SaveDatabaseCSV()
        {
            try
            {
                List<Person> people = fileCSV.GetValue();
                foreach (var person in people)
                {
                    _context.Add(person);
                }
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        // GET: api/File/write_xml
        [HttpGet("write_xml")]
        public string WriteXML()
        {
            try
            {
                List<Person> people = _context.People.ToList();
                fileXML.WriteXML(Mapping.GetMapping(people));
                return "Success";
            }
            catch
            {
                return "Error";
            }
        }
    }
}
