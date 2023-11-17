using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;

namespace CTN4_Serv.Service.Service
{
    public class LichSuHoaDonService : ILichSuHoaDonService
    {
        public DB_CTN4_ok _db;

        public LichSuHoaDonService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<LichSuDonHang> GetAll()
        {
            return _db.LichSuDonHangs.ToList();
        }

        public LichSuDonHang GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(LichSuDonHang a)
        {
            try
            {
                _db.LichSuDonHangs.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(LichSuDonHang a)
        {
            try
            {
                _db.LichSuDonHangs.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public int[] Thongkels()
        {
            DateTime startDate = DateTime.Now.AddMonths(-12);
            DateTime endDate = DateTime.Now;

            var thongKeData = _db.LichSuDonHangs
                .Where(ls => ls.ThoiGianlam >= startDate && ls.ThoiGianlam <= endDate)
                .ToList();

            // Tạo mảng để lưu trữ số lượng LichSuDonHang cho từng tháng
            int[] thongKeArray = new int[12];

            // Lặp qua danh sách và đếm số lượng trong từng tháng
            foreach (var lichSuDonHang in thongKeData)
            {
                int monthDifference = (lichSuDonHang.ThoiGianlam.Month - startDate.Month + 12) % 12;
                thongKeArray[monthDifference]++;
            }

            // Sắp xếp lại mảng theo thứ tự tháng
            int[] sortedThongKeArray = new int[12];
            for (int i = 0; i < 12; i++)
            {
                sortedThongKeArray[i] = thongKeArray[(i + startDate.Month - 1) % 12];
            }

            return sortedThongKeArray;
        }



        public bool Xoa(Guid id)
        {
            try
            {
                var b = GetById(id);
                _db.LichSuDonHangs.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
