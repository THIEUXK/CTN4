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
    public class DanhMucChiTietController : Controller
    {
        public IDanhMucChiTietService _dmct;
        public ISanPhamService _sp;
        public IDanhMucService _dm;

        public DanhMucJoin _danhMucJoin;

        public DanhMucChiTietController()
        {
            _dmct = new DanhMucChiTietMucChiTietService();
            _sp = new SanPhamService();
            _dm = new DanhMucMucService();
            _danhMucJoin = new DanhMucJoin();

        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _danhMucJoin.getAllDanhMucChitiet();
            return View(a);
        }

        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {

            var a = _dmct.GetById(id);
            return View(a);
        }

        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            var viewModel = new DanhMucChiTietView()
            {

                sanPhamItems = _sp.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                danhMucItems = _dm.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenDanhMuc
                }).ToList(),
            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMucChiTietView a)
        {
            var b = new DanhMucChiTiet()
            {

                IdSanPham = Guid.Parse(a.IdSanPhamChiTiet.Value.ToString()),
                IdDanhMuc = Guid.Parse(a.IdDanhMuc.Value.ToString()),

            };
            if (_dmct.Them(b)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }
            var viewModel = new DanhMucChiTietView()
            {
                sanPhamItems = _sp.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                danhMucItems = _dm.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenDanhMuc
                }).ToList(),
            };

            return View(viewModel);
        }

        // GET: PhanLoaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var viewModel = new DanhMucChiTietView()
            {
                sanPhamItems = _sp.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                danhMucItems = _dm.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenDanhMuc
                }).ToList(),

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMucChiTiet a)
        {
            if (_dmct.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }



        public ActionResult Delete(Guid id)
        {
            if (_dmct.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
