<%@ Page Title="Lucky Hex" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LuckyHex.aspx.cs" Inherits="WebCasino.LuckyHex" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Try hour luck in this Original game created by the Casino Hex.</h3>


    <p>
        The game consist in bet some amount of money, the system calculate your luck by the time and if you win, it will be added to your account.
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
        <asp:Label ID="LabelAdd" runat="server" CssClass="Labels" Text="Choose the player"></asp:Label>
    <p>
        <asp:Label ID="LabelIdUser" runat="server" CssClass="Labels" Text="Id:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxIdPlayer" runat="server" CssClass="form-control" Width="165px"></asp:TextBox>


        <asp:Label ID="LabelMoneyToBet" runat="server" CssClass="Labels" Text="Money to bet:"></asp:Label>
        &nbsp;<span style="color: #ff0000">*</span>

        <asp:TextBox ID="TextBoxTryLuck" runat="server" CssClass="form-control" max="99999999999" MaxLength="100" min="-99999999999" SkinID="tbxNormal" step="0.01" type="number" value="0" Width="165px">0</asp:TextBox>
        <asp:Button ID="ButtonTryLuck" runat="server" class="btn btn-success" Style="margin-top: 20px;"
            Text="Try your luck" Height="34px" OnClick="ButtonTryLuck_Click" />
    <p>
        <br>
        <asp:Label ID="LabelMessage" runat="server" CssClass="Labels" Text=""></asp:Label>
        <br />

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
