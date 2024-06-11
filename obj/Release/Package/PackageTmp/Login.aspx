<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalManagementSystem.Code.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            
            background-image: url('https://www.brookings.edu/wp-content/uploads/2017/05/hospital002.jpg');
            background-size: cover; /* Cover the entire viewport */
            background-position: center; /* Center the image */
            background-repeat: no-repeat; /* Do not repeat the image */
            font-family: Arial, sans-serif;
        }

        .container {
            width: 300px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            color: #333;
        }

        input[type="text"],
        input[type="password"],
        input[type="submit"] {
            width: 100%;
            padding: 10px;
            margin-top: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        input[type="submit"] {
            background-color: #4caf50;
            color: white;
            border: none;
            cursor: pointer;
        }

            input[type="submit"]:hover {
                background-color: #45a049;
            }
    </style>
</head>
<body>
    <center>
        <h1>Welcome to Ganata Hospitals</h1>
    </center>
    <div class="container">
        <h2>Login</h2>
        <form id="form1" runat="server">
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" Required="true"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" Required="true"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <div>
                <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Text=""></asp:Label>
            </div>

        </form>
    </div>

</body>
</html>
