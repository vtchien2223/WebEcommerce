using DoAnCoSoWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.ViewModels
{

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu cũ")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới và xác nhận mật khẩu mới không khớp.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserViewModels
    {
        public Account Register { get; set; }

        public List<Account>? accounts { get; set; }
        public ChangePasswordViewModel ChangePassword { get; set; }

        public SelectList rank { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? Revenue { get; set; }

        public List<MonthlyRevenueViewModel> MonthlyRevenues { get; set; } = new List<MonthlyRevenueViewModel>();
        public List<YearlyRevenueViewModel> YearlyRevenues { get; set; } = new List<YearlyRevenueViewModel>();
        public List<DateRevenueViewModel> DateRevenues { get; set; } = new List<DateRevenueViewModel>();
    }
}
