<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
        	<% foreach (Department department in (IEnumerable<Department>)Context.Items["blah"])
            {%>
            <tr class="ListItem">
               		 <td>                     
                        <%= department.name %>
                	</td>
           	 </tr>        
             <%
            }%>
	    </table>            
</asp:Content>
