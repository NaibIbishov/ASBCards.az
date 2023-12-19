using DataAccess.Context;
using DataAccess.Entity;
using DTO.DTOEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using OfficeOpenXml;
using System.ComponentModel;

namespace WebCards.asb.az.Controllers
{
    public class ExcelController : Controller
    {
        private readonly AppDbContext _db;

        public ExcelController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0 && (Path.GetExtension(file.FileName) == ".xlsx" || Path.GetExtension(file.FileName) == ".xls"))
                    {

                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        using (var stream = file.OpenReadStream())

                        using (var package = new ExcelPackage(stream))
                        {
                            var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                            if (workSheet != null)
                            {
                                var rowCount = workSheet.Dimension.Rows;

                                for (int row = 2; row <= rowCount; row++)
                                {
                                    var excelData = new OrderCard
                                    {
                                        Name = workSheet.Cells[row, 1].Value?.ToString(),
                                        Surname = workSheet.Cells[row, 2].Value?.ToString(),
                                        FatherName = workSheet.Cells[row, 3].Value?.ToString(),
                                        Seriya = workSheet.Cells[row, 4].Value?.ToString(),
                                        SeriyaNo = workSheet.Cells[row, 5].Value?.ToString(),
                                        VerilmeYeri = workSheet.Cells[row, 6].Value?.ToString(),
                                        Verilmetarixi = workSheet.Cells[row, 7].Value?.ToString(),
                                        Fincode = workSheet.Cells[row, 8].Value?.ToString(),
                                        TelNumber = workSheet.Cells[row, 9].Value?.ToString(),
                                        Dogumtarixi = workSheet.Cells[row, 10].Value?.ToString(),
                                        DogumYeri = workSheet.Cells[row, 11].Value?.ToString(),
                                        FatikiUnvan = workSheet.Cells[row, 12].Value?.ToString(),
                                        MotherName = workSheet.Cells[row, 13].Value?.ToString(),
                                        MotherSurname = workSheet.Cells[row, 14].Value?.ToString(),
                                        CarNo = workSheet.Cells[row, 15].Value?.ToString(),
                                        Company = workSheet.Cells[row, 16].Value?.ToString(),
                                        Status = workSheet.Cells[row, 17].Value?.ToString(),
                                        FillialKodu = workSheet.Cells[row, 18].Value?.ToString(),
                                        HesabNo = workSheet.Cells[row, 19].Value?.ToString(),
                                        SubHesab = workSheet.Cells[row, 20].Value?.ToString(),
                                        UserId = 1,
                                    };
                                    _db.OrderCards.Add(excelData);
                                    _db.SaveChanges();
                                    return RedirectToAction("Index", "Home");
                                }
                            }
                        }
                    }
                }

                
                
            }
            
                
                return View();
            
        }






        //[HttpPost]
        //public async Task<IActionResult> Upload(List<IFormFile> files)
        //{
        //    if (files != null && files.Count > 0)
        //    {
        //        foreach (var file in files)
        //        {
        //            if (file.Length > 0 && (Path.GetExtension(file.FileName) == ".xlsx" || Path.GetExtension(file.FileName) == ".xls"))
        //            {
        //                using (var stream = new MemoryStream())
        //                {
        //                    await file.CopyToAsync(stream);
        //                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        //                    using (var package = new ExcelPackage(stream))
        //                    {
        //                        var worksheet = package.Workbook.Worksheets[0];
        //                        var rowCount = worksheet.Dimension.Rows;

        //                        for (int row = 2; row <= rowCount; row++)
        //                        {
        //                            var person = new User
        //                            {
        //                                Name = worksheet.Cells[row, 1].Value.ToString(),
        //                                Email = worksheet.Cells[row, 2].Value.ToString()
        //                            };

        //                            _db.Users.Add(person);
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("files", "Sadece Excel dosyalarını yükleyebilirsiniz.");
        //                return View();
        //            }
        //        }

        //        await _db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}




        //public IActionResult FileList()
        //{
        //    var data = _db.UploadedFiles.ToList();
        //    return View(data);
        //}




        //public IActionResult Download(int id)
        //{
        //    var data = _db.UploadedFiles.Find(id);
        //    if (data != null)
        //    {
        //        var dosyaStream = new MemoryStream(data.FileData);
        //        return File(dosyaStream, "application/octet-stream", data.FileName);
        //    }

        //    return NotFound();
        //}
    }
}
