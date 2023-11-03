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
    public class KhuyenMaiPhanLoaiController : Controller
    {
        public IKhuyenMaiPhanLoaiService _kmpl;
        public IPhanLoaiService _pl;
        public IKhuyenMaiService _km;

        public KhuyenMaiPhanLoaiJoin _khuyenMaiPhanLoaiJoin;

        public KhuyenMaiPhanLoaiController()
        {
            _kmpl = new KhuyenMaiPhanLoaiService();
            _pl = new PhanLoaiService();
            _km = new KhuyenMaiService();
            _khuyenMaiPhanLoaiJoin = new KhuyenMaiPhanLoaiJoin();

        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _khuyenMaiPhanLoaiJoin.getAllKhuyenMaiPhanLoai();
            return View(a);
        }

        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {

            var a = _kmpl.GetById(id);
            return View(a);
        }

        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            var viewModel = new KhuyenMaiPhanLoaiView()
            {

                khuyenMaiItems = _km.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.MaKhuyenMai
                }).ToList(),
                phanLoaiItems = _pl.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenPhanLoai
                }).ToList(),
            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhuyenMaiPhanLoaiView a)
        {
            var b = new KhuyenMaiPhanLoai()
            {

                idKhuyenMai = Guid.Parse(a.idKhuyenMai.Value.ToString()),
                IdPhanLoai = Guid.Parse(a.IdPhanLoai.Value.ToString()),

            };
            if (_kmpl.Them(b)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }
            var viewModel = new KhuyenMaiPhanLoaiView()
            {
                khuyenMaiItems = _km.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.MaKhuyenMai
                }).ToList(),
                phanLoaiItems = _pl.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenPhanLoai
                }).ToList(),
            };

            return View(viewModel);
        }

        // GET: PhanLoaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var viewModel = new KhuyenMaiPhanLoaiView()
            {
                khuyenMaiItems = _km.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.MaKhuyenMai
                }).ToList(),
                phanLoaiItems = _pl.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenPhanLoai
                }).ToList(),

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhuyenMaiPhanLoai a)
        {
            if (_kmpl.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }



        public ActionResult Delete(Guid id)
        {
            if (_kmpl.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

