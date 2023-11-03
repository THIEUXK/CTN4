using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_View.Areas.Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class KhuyenMaiSanPhamController : Controller
    {
        public ISanPhamService _sp;
        public IKhuyenMaiSanPhamService _kmsp;
        public IKhuyenMaiService _km;

        public KhuyenMaiSanPhamJoin _khuyenMaiSanPhamJoin;

        public KhuyenMaiSanPhamController()
        {
            _sp = new SanPhamService();
            _kmsp = new KhuyenMaiSanPhamService();
            _km = new KhuyenMaiService();
            _khuyenMaiSanPhamJoin = new KhuyenMaiSanPhamJoin();

        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _khuyenMaiSanPhamJoin.getAllKhuyenMaiSanPham();
            return View(a);
        }

        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {

            var a = _kmsp.GetById(id);
            return View(a);
        }

        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            var viewModel = new KhuyenMaiSanPhamView()
            {

                SpctItems = _sp.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                KMItems = _km.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.MaKhuyenMai
                }).ToList(),
            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhuyenMaiSanPhamView a)
        {
            var b = new KhuyenMaiSanPham()
            {
                Id = Guid.NewGuid(),
                IdSanPham = Guid.Parse(a.IdSanPham.Value.ToString()),
                IdkhuyenMai = Guid.Parse(a.IdkhuyenMai.Value.ToString()),

            };
            if (_kmsp.Them(b)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }
            var viewModel = new KhuyenMaiSanPhamView()
            {
                SpctItems = _sp.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                KMItems = _km.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.MaKhuyenMai
                }).ToList(),
            };

            return View(viewModel);
        }

        // GET: PhanLoaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var viewModel = new KhuyenMaiSanPhamView()
            {
                SpctItems = _sp.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                KMItems = _km.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.MaKhuyenMai
                }).ToList(),

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhuyenMaiSanPham a)
        {
            if (_kmsp.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }



        public ActionResult Delete(Guid id)
        {
            if (_kmsp.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
