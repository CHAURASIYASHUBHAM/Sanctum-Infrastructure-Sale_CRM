using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmailSend.Models;

namespace EmailSend.Controllers
{
    public class HomeController : Controller
    {
        string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Shubham;Integrated Security=True;";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Closed()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Closed(Customer model, HttpPostedFileBase file)
        {
            string filePath = "";

            // 🔹 File Upload Logic
            if (file != null && file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);

                // Save inside project folder (~/Uploads/)
                string path = Server.MapPath("~/Uploads/");

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                string fullPath = System.IO.Path.Combine(path, fileName);
                file.SaveAs(fullPath);

                // Save relative path to DB
                filePath = "/Uploads/" + fileName;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("InsertCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parameters
                cmd.Parameters.AddWithValue("@CustomerName", model.CustomerName);
                cmd.Parameters.AddWithValue("@ProjectName", model.ProjectName);
                cmd.Parameters.AddWithValue("@FlatNo", model.FlatNo);
                cmd.Parameters.AddWithValue("@FloorWing", model.FloorWing);
                cmd.Parameters.AddWithValue("@CarpetArea", (object)model.CarpetArea ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Date", (object)model.Date ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@AgreementValue", (object)model.AgreementValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OtherCharges", (object)model.OtherCharges ?? DBNull.Value);

                // ✅ File Path Insert
                cmd.Parameters.AddWithValue("@CostSheetFilePath", filePath);

                cmd.Parameters.AddWithValue("@BrokerName", model.BrokerName);
                cmd.Parameters.AddWithValue("@BrokerMobileNumber", model.BrokerMobileNumber);
                cmd.Parameters.AddWithValue("@BrokerEmailId", model.BrokerEmailId);

                cmd.Parameters.AddWithValue("@BrokeragePercentage", (object)model.BrokeragePercentage ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@ModularKitchenType", model.ModularKitchenType);
                cmd.Parameters.AddWithValue("@GoldCoinAmount", (object)model.GoldCoinAmount ?? DBNull.Value);

                cmd.Parameters.AddWithValue("@Television", model.Television);
                cmd.Parameters.AddWithValue("@AirConditioner", model.AirConditioner);
                cmd.Parameters.AddWithValue("@Refrigerator", model.Refrigerator);

                cmd.Parameters.AddWithValue("@OtherScheme", model.OtherScheme);
                cmd.Parameters.AddWithValue("@NotApplicable", model.NotApplicable);

                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    return RedirectToAction("Success", "Home");
                }
                return View();
            }
        }

        public JsonResult GetCarpetArea(string flatNo)
        {
            decimal area = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Area FROM Floor WHERE FloorNo = @FlatNo";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FlatNo", flatNo);

                con.Open();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    area = Convert.ToDecimal(result);
                }
            }

            return Json(area, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Success()
        {
            return View();
        }

    }
}