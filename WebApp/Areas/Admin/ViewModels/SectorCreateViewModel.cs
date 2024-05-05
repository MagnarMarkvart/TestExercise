using App.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels;

public class SectorCreateViewModel
{
    public Sector Sector { get; set; } = default!;
    public SelectList? SectorSelectList { get; set; }
}