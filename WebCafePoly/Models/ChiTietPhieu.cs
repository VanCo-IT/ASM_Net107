using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebCafePoly.Models;

[Table("ChiTietPhieu")]
public partial class ChiTietPhieu
{
    [Key]
    public int Id { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string MaPhieu { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string MaSanPham { get; set; } = null!;

    public int SoLuong { get; set; }

    [Column(TypeName = "decimal(10, 0)")]
    public decimal DonGia { get; set; }

    [ForeignKey("MaPhieu")]
    [InverseProperty("ChiTietPhieus")]
    public virtual PhieuBanHang MaPhieuNavigation { get; set; } = null!;

    [ForeignKey("MaSanPham")]
    [InverseProperty("ChiTietPhieus")]
    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
