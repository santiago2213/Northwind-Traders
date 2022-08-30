<%@ Page Title="Suppliers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="Santiago_HW3.SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<asp:DataList ID="DataList1" runat="server">    
    <ItemTemplate>
        <div class="card" style="text-align:center">
            
            <img class="card-img-top" src="Images/<%#Eval("SupplierImage").ToString()%>" style="width:50px; height:50px"/>

            <div class="card-body">

                <h3 class="card-title">
                    <%#Eval("Company").ToString()%>
                    <%#Eval("SupplierID").ToString()%>
                </h3>

                <p class="card-text">
                    <%#Eval("LastName").ToString()%>
                    <%#Eval("FirstName").ToString() %>
                    <br />
                    <%#Eval("BusinessPhone").ToString()%>
                    <%#Eval("City").ToString()%>
                    <%#Eval("State").ToString()%>
                </p>
                <hr />
     
                <div class="card-footer">
                    <a class="btn btn-primary" href="SupplierDetails.aspx?SupplierID=<%#Eval("SupplierID").ToString()%>">More Details</a>
                </div>

            </div>

        </div>

    </ItemTemplate>

</asp:DataList>

</asp:Content>