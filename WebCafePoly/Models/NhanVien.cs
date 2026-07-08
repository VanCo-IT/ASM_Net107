using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebCafePoly.Models;

[Table("NhanVien")]
[Index("Email", Name = "UQ__NhanVien__A9D1053436446174", IsUnique = true)]
public partial class NhanVien
{
    [Key]
    [StringLength(6)]
    [Unicode(false)]
    public string MaNhanVien { get; set; } = null!;

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string MatKhau { get; set; } = null!;

    public bool VaiTro { get; set; }

    public bool TrangThai { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<PhieuBanHang> PhieuBanHangs { get; set; } = new List<PhieuBanHang>();
}
