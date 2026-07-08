using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebCafePoly.Models;

[Table("KhachHang")]
public partial class KhachHang
{
    [Key]
    [StringLength(50)]
    public string MaKhachHang { get; set; } = null!;

    [StringLength(50)]
    public string? HoTen { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? SoDienThoai { get; set; }

    [StringLength(50)]
    public string? MatKhau { get; set; }

    [StringLength(50)]
    public string? DiaChi { get; set; }

    public bool? TrangThai { get; set; }

    [InverseProperty("MaKhachHangNavigation")]
    public virtual ICollection<PhieuBanHang> PhieuBanHangs { get; set; } = new List<PhieuBanHang>();
}
