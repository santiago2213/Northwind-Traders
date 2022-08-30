<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Santiago_HW3.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DataList ID="DataList1" runat="server" RepeatColumns="2">    
    <ItemTemplate>
        <div class="card" style="text-align:center">
            
            <img class="card-img-top" src="Images/<%#Eval("ProdImage" ).ToString()%>" style="width:50px; height:50px"/>

            <div class="card-body">

                <h3 class="card-title">
                    <%#Eval("ProductName").ToString()%>
                </h3>

                <p class="card-text">
                    Price:
                    <%#Eval("ListPrice", "{0:c}").ToString()%>
                    <br />
                    In Stock:
                    <%#Eval("AvailableQty").ToString() %>
                    <br />
                    Product ID:
                    <%#Eval("ProductID").ToString()%>
                    <br />
                    Supplier ID:
                    <%#Eval("SupplierID").ToString()%>
                    <br />
                    Product Code:
                    <%#Eval("ProductCode").ToString()%>
                </p>
                <hr />
     
                <div class="card-footer">
                    <a class="btn btn-primary" href="ProductDetails.aspx?ProductID=<%#Eval("ProductID").ToString()%>">More Details</a>
                </div>

            </div>

        </div>

    </ItemTemplate>

</asp:DataList>


</asp:Content>
