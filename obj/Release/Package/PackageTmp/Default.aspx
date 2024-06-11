<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HospitalManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>

    <main>
        <style>
            body {
                background-color: #f0f8ff; /* Light blue color */
            }

            .row {
                display: flex;
                justify-content: space-between;
                align-items: center;
                text-align: center;
            }

            #container {
                display: flex;
                justify-content: center;
                align-items: center;
                margin-bottom: 30px;
                color: aqua;
            }

            .col-3 {
                width: 33.33%;
                float: left;
                padding: 5px;
            }

            .cards {
                height: 150px;
                width: 150px;
                border: 2px solid black;
                background-color: #f9f9f9;
                border: 1px solid #eaeaea;
                border-radius: 8px;
                padding: 20px;
                text-align: center;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                transition: transform 0.3s ease;
            }

                .cards:hover {
                    transform: translateY(-5px);
                }

            #card1 {
                color: purple;
                font-weight: bold;
                font-size: 20px;
                height: 150px;
                width: 200px;
            }


            #card2 {
                color: purple;
                font-weight: bold;
                font-size: 20px;
                height: 150px;
                width: 200px;
            }


            #card3 {
                color: purple;
                font-weight: bold;
                font-size: 20px;
                height: 150px;
                width: 220px;
            }


            /* Style for the form container */
            .form-container {
                max-width: 500px;
                margin: 0 auto;
                padding: 20px;
                border-radius: 10px;
                background-color: #fff;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            }

            /* Style for the headings */
            h2 {
                text-align: center;
                color: #333;
            }
        </style>

        <asp:Panel ID="PanelDashboard" runat="server" Visible="true">

            <div class="row">
                <div class="col-3">
                    <div id="card1" class="cards">
                        <h3>PATIENT DETAILS</h3>
                        <p>Profile</p>
                    </div>
                </div>

                <div class="col-3">
                    <div id="card2" class="cards">
                        <h3>MEDICAL REPORT</h3>
                        <p>Health Snapshot</p>
                    </div>
                </div>

                <div class="col-3">
                    <div id="card3" class="cards">
                        <h3>APPOINTMENT</h3>
                        <p>Schedule</p>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="chart" runat="server">
            <div>
                <asp:Literal ID="barchart" runat="server"></asp:Literal>
            </div>
            <div>
                <asp:Literal ID="piechart" runat="server"></asp:Literal>
            </div>
        </asp:Panel>

    </main>

</asp:Content>
