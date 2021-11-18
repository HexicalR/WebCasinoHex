<%@ Page Title="Our Players" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Players.aspx.cs" Inherits="WebCasino.Players" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Here you can find all the players who are in the current Casino Hex.</h3>


    <p>
    </p>
    <table>
        <tr>
            <td class="auto-style6">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Width="897px">
                    <asp:GridView ID="GridViewPlayers" runat="server" AllowPaging="True" AllowSorting="True"
                        OnPageIndexChanging="GridViewPlayers_PageIndexChanging" EmptyDataText="NO PLAYER RECORDS"
                        OnSelectedIndexChanged="GridViewPlayers_SelectedIndexChanged" Width="897px"
                        OnSorting="GridViewPlayers_Sorting">
                        <Columns>
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Right.png" ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle"
                            Height="50px" CssClass="table-primary" />
                        <RowStyle Wrap="True" CssClass="table-secondary" />
                        <AlternatingRowStyle CssClass="table-light" />
                        <SelectedRowStyle Font-Bold="True" CssClass="table-dark" />
                        <PagerStyle HorizontalAlign="Left" CssClass="pagination-ys" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>

    <p>
        <br>
        <br />
        <asp:Label ID="LabelAdd" runat="server" CssClass="Labels" Text="Add a new Player"></asp:Label>
    <p>
        <asp:Label ID="LabelAddName" runat="server" CssClass="Labels" Text="Name:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxAddPlayerName" runat="server" CssClass="form-control" Width="165px"></asp:TextBox>

        <asp:Label ID="LabelAddLastName" runat="server" CssClass="Labels" Text="LastName:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxAddPlayerLastName" runat="server" CssClass="form-control" Width="165px"></asp:TextBox>

        <asp:Label ID="LabelUserName" runat="server" CssClass="Labels" Text="Username:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxUserName" runat="server" CssClass="form-control" Width="165px"></asp:TextBox>

                <asp:Label ID="LabelPassword" runat="server" CssClass="Labels" Text="Password:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="form-control" Width="165px"></asp:TextBox>

        <asp:Label ID="LabelMoneyAccount" runat="server" CssClass="Labels" Text="MoneyAccount:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxAddMoneyAccount" runat="server" CssClass="form-control" max="99999999999" MaxLength="100" min="-99999999999" SkinID="tbxNormal" step="0.01" type="number" value="0" Width="165px">0</asp:TextBox>
        <asp:Button ID="ButtonAddPlayer" runat="server" class="btn btn-success" Style="margin-top: 20px;"
            Text="Add new player" Height="34px" OnClick="ButtonAddPlayer_Click" />
    <p>
    <p>
        <br>
        <br />
        <asp:Label ID="LabelUpdatePlayer" runat="server" CssClass="Labels" Text="Update the player selected"></asp:Label>
    <p>
        <asp:Label ID="LabelUpdatePlayerName" runat="server" CssClass="Labels" Text="Name:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>
        <asp:TextBox ID="TextBoxUpdatePlayer" runat="server" CssClass="form-control" Width="165px"></asp:TextBox>

        <asp:Label ID="LabelUpdatePlayerLastName" runat="server" CssClass="Labels" Text="Last Name:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxUpdateLastName" runat="server" CssClass="form-control" Width="165px"></asp:TextBox>
        <asp:Label ID="LabelUpdateMoneyAccount" runat="server" CssClass="Labels" Text="MoneyAccount:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxUpdateMoneyAccount" runat="server" CssClass="form-control" max="99999999999" MaxLength="100" min="-99999999999" SkinID="tbxNormal" step="0.01" type="number" value="0" Width="165px">0</asp:TextBox>

        <asp:Button ID="ButtonUpdatePlayer" runat="server" class="btn btn-info" Style="margin-top: 20px;"
            Text="Update player" Height="34px" OnClick="ButtonUpdatePlayer_Click" />
    <p>
        <br>
        <p>
            <br />

            <asp:Label ID="LabelDelete" runat="server" CssClass="Labels" Text="Delete the player selected"></asp:Label>
    <p>
        <asp:Button ID="ButtonDeletePlayer" runat="server" class="btn btn-danger" Style="margin-top: 20px;"
            Text="Delete player" Height="34px" OnClick="ButtonDeletePlayer_Click" />
    <p>
        <br>
        <br />
        <br>
        <br />
        <br>
        <br />
        <p>Additional information.</p>
    <asp:Label ID="LabelNote" runat="server" CssClass="Ettiquets" Text="The fields marked with"> </asp:Label>
    &nbsp;<span style="color: #ff0000">*</span>
    <span>are required.</span>
</asp:Content>
