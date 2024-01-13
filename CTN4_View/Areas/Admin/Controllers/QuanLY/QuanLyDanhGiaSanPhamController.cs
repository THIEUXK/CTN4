using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CTN4_Serv.ViewModel;

namespace CTN4_View.Areas.Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class QuanLyDanhGiaSanPhamController : Controller
    {
        public IDanhGiaSanPhamService _danhGiaSanPhamService;

        public QuanLyDanhGiaSanPhamController()
        {
            _danhGiaSanPhamService = new DanhGiaSanPhamService();
        }
        // GET: DanhGiaSanPhamController
        public ActionResult Index()
        {
            var listDanhGias = _danhGiaSanPhamService.GetAll().Where(c => c.TrangThaiDuyet == false && c.Is_delete == true).ToList();
            //var DanhGiaDaDuocDuyet = _danhGiaSanPhamService.GetAll().Where(c => c.TrangThaiDuyet == true && c.Is_delete == true).ToList();
            //var listDanhGiaDaXoas = _danhGiaSanPhamService.GetAll().Where(c => c.TrangThaiDuyet == false && c.Is_delete == false).ToList();
            //var a = new ListDanhGiaView()
            //{
            //    SanPhamDaDanhGia = DanhGiaDaDuocDuyet,
            //    DuyetDanhGia = listDanhGias,
            //    DanhGiaBiAn = listDanhGiaDaXoas
            //};
            return View(listDanhGias);
        }
        public ActionResult DanhGiaDaDuocDuyet()
        {
            var DanhGiaDaDuocDuyet = _danhGiaSanPhamService.GetAll().Where(c => c.TrangThaiDuyet == true && c.Is_delete == true).ToList();
            return View("Index", DanhGiaDaDuocDuyet);
        }
        // GET: DanhGiaSanPhamController/Details/5
        public ActionResult DanhGiaDaXoa()
        {
            var listDanhGiaDaXoas = _danhGiaSanPhamService.GetAll().Where(c => c.TrangThaiDuyet == false && c.Is_delete == false).ToList();
            return View("Index", listDanhGiaDaXoas);

        }

        public ActionResult DuyetDanhGia(Guid id)
        {
            // Lấy đánh giá từ cơ sở dữ liệu
            var danhGia = _danhGiaSanPhamService.GetById(id);
            // Đặt trạng thái duyệt là true
            danhGia.TrangThaiDuyet = true;

            // Lưu thay đổi vào cơ sở dữ liệu
            _danhGiaSanPhamService.Sua(danhGia);

            // Chuyển hướng hoặc trả về JSON tùy thuộc vào yêu cầu của bạn
            return RedirectToAction("Index"); // Chuyển hướng đến trang danh sách đánh giá
        }

        // Action để xử lý từ chối đánh giá
        public ActionResult TuChoiDanhGia(Guid id)
        {
            // Lấy đánh giá từ cơ sở dữ liệu
            var danhGia = _danhGiaSanPhamService.GetById(id);
            // Đặt trạng thái duyệt là false
            danhGia.Is_delete = false;
            // Lưu thay đổi vào cơ sở dữ liệu
            _danhGiaSanPhamService.Sua(danhGia);
            // Chuyển hướng hoặc trả về JSON tùy thuộc vào yêu cầu của bạn
            return RedirectToAction("Index"); // Chuyển hướng đến trang danh sách đánh giá
        }

    
        // POST: DanhGiaSanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhGiaSanPhamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhGiaSanPhamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
