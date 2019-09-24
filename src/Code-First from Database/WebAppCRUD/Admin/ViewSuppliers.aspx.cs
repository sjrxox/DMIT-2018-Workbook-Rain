using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCRUD.Admin
{
    public partial class ViewSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SupplierLisView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // This fires just before ListView calls 
            // the ObjectDataSource control to do an insert.
            ; // no-op 
        }

        protected void SupplierLisView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            // This event is fired afterthe ObjectDatSource
            // has returned from performing an insert.
            ; 
        }

        protected void SupplierDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ; // Before calling the BLL 
        }

        protected void SupplierDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ; // After the call to the BLL

            if(e.Exception != null)
            {
                Exception inner = e.Exception;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                string message = $"Problem inserting<blockquote>{ inner.Message}</blockquote>";
                MessageLabel.Text = message;
                e.ExceptionHandled = true;
            }
        }
    }
}