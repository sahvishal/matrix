<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_Admin_Feedback" Codebehind="Feedback.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="mainbody_outer">
    <div class="mainbody_inner">
    <div class="main_area_bdrnone">
            <div class="maindivinner_feedback">
            <div class="maindivinnerrow_feedback">
            <div class="headingbox_feedback">
            <span class="orngheadtxt_feedback">Feedback</span>
            </div>
            </div>
            <p><img src="../../Images/specer.gif" width="500px" height="5px" /></p>
            <p class="graylinefull_feedback"><img src="../../Images/specer.gif" width="1px" height="1px" /></p>
            <div class="feedbacktopbg"><img src="../../Images/specer.gif" width="750px" height="6px" /></div>
            <p class="blueheadingbox_feedback">
            <span class="bluheadtxt_fadmin">Send Us Your Feedback</span>
            </p>
            <div class="lightbluebox_feedback">
            <p class="lightblueboxrow_feedback">
            <span class="titletext_feedback">Title:</span>
            <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox1" runat="server" CssClass="inputf_def" Width="540px"></asp:TextBox></span>
            </p>
             <p class="lightblueboxrow_feedback">
            <span class="titletext_feedback">Details:</span>
            <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox3" TextMode="MultiLine" Rows="5" runat="server" CssClass="inputf_def" Width="540px"></asp:TextBox></span>
            </p>
             <p class="lightblueboxrow_feedback">
            <span class="titletext_feedback">Upload Video/Audio:</span>
            <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox6" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox></span>
            <span class="buttonconleft3_default"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App/Images/browsenew-button.gif"/></span>
            <span class="buttonconleft_default"><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/App/Images/attach-btn.jpg"/></span>
            </p>
            <p class="lightblueboxrow_feedback">
            <span class="titletext_feedback"><img src="../../Images/specer.gif" width="120px" height="1px" /></span>
            <span class="inputfldnowidth_default"><img src="../../Images/avformat-icon.gif" />&nbsp;<a href="#">testreport1.wmv</a></span>
            </p>
            <p><img src="../../Images/specer.gif" width="750" height="25px" /></p> 
            </div>
            <div class="headbg2_box_accm">
                <div class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtnsave" ImageUrl="~/App/Images/add-btn.gif" /></div>
                </div>
             <p class="maindivinnerrow_feedback">
              <span class="orngtxtbld_urm">My Feedback History</span>
             </p>
             <p class="graylinefull_feedback"><img src="../../Images/specer.gif" width="1px" height="1px" /></p>
             <p class="maindivinnerrow_feedback">
             <span class="lightblutxt_feedback">Added on: 23rd April 2008</span>
             <span class="rightheadtxt_feedback"><img src="../../Images/video-icon.gif" />&nbsp;<a href="#">(1)video</a>&nbsp;&nbsp;|&nbsp;&nbsp;<img src="../../Images/sound-icon.gif" />&nbsp;Audio (0)</span>
             </p>
              <p class="maindivinnerrow_feedback">
              <span class="feedbackheading">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt </span>
              </p>
              <p class="maindivinnerrow_feedback">
              <span class="normaltxt_feedback">"This is just a sample text and this can be remove as per requirement"...........Suspendisse potenti. In sit amet urna. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;
               Maecenas euismod, arcu a commodo hendrerit, augue arcu tempus odio, id dictum libero diam ut purus. Mauris lacus. Pellentesque eros. Mauris convallis.
               Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie
               Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie</span>
              </p>
              <p><img src="../../Images/specer.gif" width="20px" height="10px" /></p>
              <p class="graylinefull_feedback"><img src="../../Images/specer.gif" width="1px" height="1px" /></p>
              
             <p class="maindivinnerrow_feedback">
             <span class="lightblutxt_feedback">Added on: 23rd April 2008</span>
             <span class="rightheadtxt_feedback"><img src="../../Images/video-icon.gif" />&nbsp;<a href="#">(1)video</a>&nbsp;&nbsp;|&nbsp;&nbsp;<img src="../../Images/sound-icon.gif" />&nbsp;Audio (0)</span>
             </p>
             <p class="maindivinnerrow_feedback">
              <span class="feedbackheading">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt </span>
              </p>
              <p class="maindivinnerrow_feedback">
              <span class="normaltxt_feedback">"This is just a sample text and this can be remove as per requirement"...........Suspendisse potenti. In sit amet urna. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;
               Maecenas euismod, arcu a commodo hendrerit, augue arcu tempus odio, id dictum libero diam ut purus. Mauris lacus. Pellentesque eros. Mauris convallis.
               Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie
               Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie</span>
              </p>
              <p><img src="../../Images/specer.gif" width="20px" height="10px" /></p>
              <p class="graylinefull_feedback"><img src="../../Images/specer.gif" width="1px" height="1px" /></p>
              <p class="maindivinnerrow_feedback">
             <span class="lightblutxt_feedback">Added on: 23rd April 2008</span>
             <span class="rightheadtxt_feedback"><img src="../../Images/video-icon.gif" />&nbsp;<a href="#">(1)video</a>&nbsp;&nbsp;|&nbsp;&nbsp;<img src="../../Images/sound-icon.gif" />&nbsp;Audio (0)</span>
             </p>
             <p class="maindivinnerrow_feedback">
              <span class="feedbackheading">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt </span>
              </p>
              <p class="maindivinnerrow_feedback">
              <span class="normaltxt_feedback">"This is just a sample text and this can be remove as per requirement"...........Suspendisse potenti. In sit amet urna. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;
               Maecenas euismod, arcu a commodo hendrerit, augue arcu tempus odio, id dictum libero diam ut purus. Mauris lacus. Pellentesque eros. Mauris convallis.
               Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie
               Ut augue. Maecenas quis elit. Morbi non nulla vel ante mattis molestie</span>
              </p>
               <p><img src="../../Images/specer.gif" width="20px" height="30px" /></p>
</div>
    </div>
</div>
</div>
</asp:Content>
