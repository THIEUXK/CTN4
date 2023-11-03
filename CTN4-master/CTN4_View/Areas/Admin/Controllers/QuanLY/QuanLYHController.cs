﻿using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class QuanLYHController : Controller
    {
        public ISanPhamChiTietService _sv;
        public IChatLieuService _chatLieuService;
        public INSXService _nsxService;
        public ISanPhamService _spService;
        public IMauService _mauService;
        public ISizeService _sizeService;
        public SanPhamCuaHangService _sanPhamCuaHangService;
        public DB_CTN4_ok _db;
        public IAnhService _anhService;
        public ISanPhamChiTietService _sanPhamChiTietService;

        public QuanLYHController()
        {
            _sanPhamChiTietService = new SanPhamChiTietService();
            _sv = new SanPhamChiTietService();
            _chatLieuService = new ChatLieuService();
            _mauService = new MauService();
            _nsxService = new NSXService();
            _spService = new SanPhamService();
            _sizeService = new SizeService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _db = new DB_CTN4_ok();
            _anhService = new AnhService();

        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sanPhamCuaHangService.GetAllSpct();
            return View(a);
        }

        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {
            var view = new ThieuxkView()
            {
                SanPhamChiTiet = _sv.GetById(id),
                AhList = _db.Anhs.Where(c => c.IdSanPhamChiTiet == id).ToList()
            };
            return View(view);
        }

        [HttpPost]
        public async Task<ActionResult> AddAnh(Guid IdSP, List<IFormFile> imageFile,Guid IdMau,Guid idSPCT)
        {
            var listAnh = imageFile.ToList();
            foreach(var anh in listAnh){
            if (anh != null && anh.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", anh.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    anh.CopyTo(stream);
                }

            }

            if (anh != null)
            {
                {
                        foreach (var a in _sanPhamChiTietService.GetAll().Where(c=>c.IdSp==IdSP&&c.IdMau==IdMau))
                        {
                            _db.Anhs.Add(new Anh()
                            {
                                IdSanPhamChiTiet = a.Id,
                                DuongDanAnh = anh.FileName,
                                Is_delete = true,
                                TrangThai = true,
                                TenAnh = anh.FileName
                            });
                            await _db.SaveChangesAsync();
                        }             
                }
            } }


            return RedirectToAction("Details", new { id = idSPCT });
        }
        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            var viewModel = new SanPhamChiTietView()
            {


                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),

                SpItems = _spService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPhamChiTiet a)
        {
            var b = new SanPhamChiTiet()
            {
                //MaSp = a.MaSp,
                //IdChatLieu = Guid.Parse(a.IdChatLieu.Value.ToString()),
                //IdNSX = Guid.Parse(a.IdNSX.Value.ToString()),
                //IdMau = Guid.Parse(a.IdMau.Value.ToString()),
                //IdSize = Guid.Parse(a.IdSize.Value.ToString()),
                //IdSp = Guid.Parse(a.IdSp.Value.ToString()),
                //SoLuong = a.SoLuong,
                //MoTa = a.MoTa,
                //TrangThai = a.TrangThai,
                //GiaNhap = a.
                //    GiaNhap,
                //GiaBan = a.GiaBan,
                //GiaNiemYet = a.GiaNiemYet,
                //GhiChu = a.GhiChu,
                //Is_detele = a.Is_detele
            };
            if (_sv.Them(b)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }
            var viewModel = new SanPhamChiTietView()
            {
                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),
                SpItems = _spService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),

            };

            return View(viewModel);
        }

        // GET: PhanLoaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var viewModel = new SanPhamChiTietView()
            {

                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),

                SpItems = _spService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),

                SnaSanPhamChiTiet = _sv.GetById(id)

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPhamChiTiet a)
        {
            if (_sv.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }



        public ActionResult Delete(Guid id)
        {
            if (_sv.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult XoaAnh(Guid id, Guid IdSp)
        {
            if (_anhService.Xoa(id))
            {
                return RedirectToAction("Details", new { id = IdSp });
            }
            return RedirectToAction("Details", new { id = IdSp });
        }
    }
}