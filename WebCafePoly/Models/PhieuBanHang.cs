using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebCafePoly.Models;

[Table("PhieuBanHang")]
public partial class PhieuBanHang
{
    [Key]
    [StringLength(6)]
    [Unicode(false)]
    public string MaPhieu { get; set; } = null!;

    [StringLength(50)]
    public string? MaKhachHang { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? MaThe { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string? MaNhanVien { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgayTao { get; set; }

    public bool TrangThai { get; set; }

    [InverseProperty("MaPhieuNavigation")]
    public virtual ICollection<ChiTietPhieu> ChiTietPhieus { get; set; } = new List<ChiTietPhieu>();

    [ForeignKey("MaKhachHang")]
    [InverseProperty("PhieuBanHangs")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("PhieuBanHangs")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    [ForeignKey("MaThe")]
    [InverseProperty("PhieuBanHangs")]
    public virtual TheLuuDong? MaTheNavigation { get; set; }
}
