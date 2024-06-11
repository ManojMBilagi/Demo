<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMembers.aspx.cs" Inherits="HospitalManagementSystem.ViewMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
       
        <style>
            body {
                background-image: url('https://th.bing.com/th/id/OIP.LBQRN8UwxKIsS9y2TG5q3QHaE8?pid=ImgDet&w=60&h=60&c=7&dpr=1.5&rs=1');
                background-size: cover; /* Cover the entire viewport */
                background-position: center; /* Center the image */
                background-repeat: no-repeat; /* Do not repeat the image */
                font-family: Arial, sans-serif;
            }

            #PanelRegister {
                margin: 50px auto;
                max-width: 500px;
                background-color: #f9f9f9;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            }

            h2 {
                margin-bottom: 20px;
                color: #333;
            }

            table {
                width: 50%;
            }

            td {
                padding: 10px;
                vertical-align: middle;
                text-align: left;
            }

            input[type="text"],
            input[type="date"],
            select {
                width: calc(100% - 20px);
                padding: 8px;
                border: 1px solid #ccc;
                border-radius: 5px;
                margin-bottom: 10px;
            }

            .btn {
                padding: 10px 20px;
                margin-right: 10px;
                background-color: red;
                color: #fff;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                transition: background-color 0.3s;
            }

                .btn:hover {
                    background-color: #0056b3;
                }
        </style>


        <asp:Panel ID="PanelGrid" runat="server" Visible="true">

            <div>
                <asp:Button ID="Button1" CssClass="btn btn-danger" Text="AddMembers" runat="server" OnClick="btnAddMembers_Click" />
                <asp:Button ID="Button2" CssClass="btn btn-danger" Text="Download" runat="server" OnClick="btnDownload_Click" />
            </div>
            <br />

            <asp:GridView runat="server" ID="gvPat" AutoGenerateColumns="false" HeaderStyle-BackColor="YellowGreen"
                BackColor="#ccff99" BorderWidth="5" BorderColor="WindowFrame" OnPageIndexChanged="gvPat_PageIndexChanged"
                OnRowCommand="gvPat_RowCommand">
            </asp:GridView>
        </asp:Panel>


        <asp:Panel ID="PanelRegister" runat="server" Visible="false">
            <center>
                <h2>PATIENTS REGISTRATION FORM</h2>
                <table>
                    <tr>
                        <td>Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server" AutoComplete="off" placeholder="Enter Your Name" Required="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexName" runat="server" ControlToValidate="txtname"
                                ValidationExpression="^[a-zA-Z\s]*$" ErrorMessage="Only letters and spaces are allowed"
                                Display="Dynamic" />
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="Red"  Display="Dynamic" />
                        </td>
                    </tr>


                    <tr>
                        <td>Email Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" AutoComplete="off" placeholder="Enter Your EmailId" Required="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtemail"
                                ValidationExpression="^[a-zA-Z][a-zA-Z0-9._\-]*@[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4}$"
                                ErrorMessage="Invalid email format. It should start with characters, allow numbers, letters, periods, underscores, or hyphens, and end with @gmail.com" 
                                Display="Dynamic" />
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Email is required" ForeColor="Red" 
                                Display="Dynamic" />
                        </td>
                    </tr>

                    <tr>
                        <td>Phone Number
                        </td>
                        <td>
                            <asp:TextBox ID="txtphone" runat="server" AutoComplete="off" placeholder="Enter Your PhoneNumber" Required="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexPhone" runat="server" ControlToValidate="txtphone"
                                ValidationExpression="^(6|7|8|9)\d{9}$" ErrorMessage="Invalid Format. Phone number should start with 6, 7, 8, or 9 and be 10 digits long."
                                Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtphone" ErrorMessage="Phone Number is required" ForeColor="Red" 
                                Display="Dynamic" />       
                        </td>
                    </tr>

                    <tr>
                        <td>Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" AutoComplete="off" placeholder="Enter Your Address" Required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtaddress" ErrorMessage="Address is required" ForeColor="Red" 
                                Display="Dynamic" />
                        </td>
                    </tr>


                    <tr>
                        <td>Date of Birth
                        </td>
                        <td>
                            <asp:TextBox ID="txtdob" runat="server" TextMode="Date" AutoComplete="off" placeholder="YYYY-MM-DD" Required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtdob" ErrorMessage="Date of Birth is required" ForeColor="Red" 
                                Display="Dynamic" />
                        </td>
                    </tr>

                    <tr>
                        <td>Age
                        </td>
                        <td>
                            <asp:TextBox ID="txtage" runat="server" AutoComplete="off" placeholder="Enter Your Age" Required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtage" ErrorMessage="Age is required" ForeColor="Red"  Display="Dynamic" />
                            <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtage" Type="Integer" MinimumValue="1" MaximumValue="100"
                                ErrorMessage="Age must be between 1 and 100" Display="Dynamic" />
                        </td>
                    </tr>

                    <tr>
                        <td>Gender
                        </td>

                        <td>
                            <asp:RadioButtonList ID="txtgender" runat="server" Required="true">
                                <asp:ListItem Text="Male" Value="M" ></asp:ListItem>
                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="txtgender"
                               ErrorMessage="Please select a gender" Text="*Gender is required" ForeColor="Red" />
                        </td>
                    </tr>

                    <tr>
                        <td>Disease
                        </td>
                        <td>
                            <asp:DropDownList ID="ddldisease" runat="server" Width="200px" AutoPostBack="true" Required="true" >
                            </asp:DropDownList>              
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnClear" class="btn btn-danger" runat="server" Text="Clear" OnClick="btnClear_Click" />

                        </td>

                    </tr>

                </table>

            </center>
        </asp:Panel>

    </main>

</asp:Content>

