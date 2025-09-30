using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai02.Models
{
	public class DuLieu
	{
		static string strcon = "Data Source=A110PC10\\CSSQL08;Database=QL_NhanSu;User ID=sa;Password=123; Trusted_Connection=True";

		SqlConnection con = new SqlConnection(strcon);
		public List<Employee> dsNV = new List<Employee>();

		public void ThietLap_DSNV()
		{
			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EMPLOYEE", con);
			DataTable dt = new DataTable();
			da.Fill(dt);

			foreach(DataRow dr in dt.Rows)
			{
				var em = new Employee();
				em.MaNV = int.Parse(dr["ID"].ToString());
				em.Ten = dr["NAME"].ToString();
				em.GioiTinh = dr["GENDER"].ToString();
				em.Tinh = dr["CITY"].ToString();
				em.MaPg = (int)dr["DEPT_ID"];

				dsNV.Add(em);
			}
		}

		public List<Department> dsPB = new List<Department>();

        public void ThietLap_DSPB()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DEPARTMENT", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var pb = new Department();
                pb.MaPg = int.Parse(dr["DEPT_ID"].ToString());
                pb.TenPg = dr["NAME"].ToString();

                dsPB.Add(pb);
            }
        }

        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPB();
        }
    }
}