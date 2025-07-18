using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoNguyenTrongWPF.Commands
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Validate một object dựa trên DataAnnotations.
        /// </summary>
        /// <param name="obj">Object cần validate</param>
        /// <param name="validationResults">Danh sách lỗi trả về</param>
        /// <returns>True nếu hợp lệ, False nếu có lỗi</returns>
        public static bool ValidateObject(object obj, out List<ValidationResult> validationResults)
        {
            var context = new ValidationContext(obj, null, null);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, validationResults, true);
        }

        /// <summary>
        /// Trả về chuỗi lỗi gộp lại từ kết quả validate.
        /// </summary>
        public static string GetErrorMessage(List<ValidationResult> validationResults)
        {
            if (validationResults == null || validationResults.Count == 0)
                return string.Empty;

            return string.Join("\n", validationResults.ConvertAll(r => r.ErrorMessage));
        }
    }
}
