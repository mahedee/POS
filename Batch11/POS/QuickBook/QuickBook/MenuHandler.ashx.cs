using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace QuickBook
{
    /// <summary>
    /// Summary description for MenuHandler
    /// </summary>
    public class MenuHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<Menu> listMenu = new List<Menu>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetMenuData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Menu menu = new Menu();
                    menu.ID = Convert.ToInt32(rdr["ID"]);
                    menu.MenuName = rdr["MenuName"].ToString();
                    menu.ParentMenuId = Convert.ToInt32(rdr["ParentMenuId"]);
                    listMenu.Add(menu);
                }
            }
            List<Menu> menuTree = GetMenuTree(listMenu,0);

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(menuTree));
        }
       
        private List<Menu> GetMenuTree(List<Menu> list,int parentMenuId)
        {
            return list.Where(x => x.ParentMenuId == parentMenuId).Select(x => new Menu()
            {
                ID = x.ID,
                MenuName = x.MenuName,
                ParentMenuId = x.ParentMenuId,
                List = GetMenuTree(list,x.ID)
            }).ToList();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}