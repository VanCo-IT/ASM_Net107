using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebCafePoly.Models;

[Table("LoaiSanPham")]
[Index("TenLoai", Name = "UQ__LoaiSanP__E29B104251013E38", IsUnique = true)]
public partial class LoaiSanPham
{
    [Key]
    [StringLength(6)]
    [Unicode(false)]
    public string MaLoai { get; set; } = null!;

    [StringLength(100)]
    public string TenLoai { get; set; } = null!;

    public string? GhiChu { get; set; }

    [InverseProperty("MaLoaiNavigation")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
