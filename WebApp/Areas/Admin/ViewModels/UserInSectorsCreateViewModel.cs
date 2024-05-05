using App.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels;

public class UserInSectorsCreateViewModel
{
    public UserInSector UserInSector { get; set; } = default!;
    public SelectList? Sectors { get; set; }
    public SelectList? Users { get; set; }
}