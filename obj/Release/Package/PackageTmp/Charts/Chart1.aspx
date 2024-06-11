<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart1.aspx.cs" Inherits="HospitalManagementSystem.Charts.Chart1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
<body>
    <div>
        <asp:Literal ID="barchart" runat="server"></asp:Literal>
    </div>
    <div>
        <asp:Literal ID="piechart" runat="server"></asp:Literal>
    </div>
    <div>
        <asp:Literal ID="linechart" runat="server"></asp:Literal>
    </div>
</body>
</html>
