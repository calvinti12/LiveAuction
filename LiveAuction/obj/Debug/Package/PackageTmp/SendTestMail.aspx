<%@ Page Language="C#" Debug="true" %>
<%@ Import Namespace="System.Net.Mail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void Page_Load()
    {
        MailMessage oMessage = new MailMessage();
        oMessage.From = new MailAddress("stsservices16@gmail.com", "ABP Admin");             
        oMessage.To.Add("anjans@skylofttechnology.com");
        oMessage.Subject = "Test Mail";
        oMessage.Body = "Test mail";
        //oMessage.IsBodyHtml = false;
        oMessage.Priority = MailPriority.High;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        //smtpClient.Host = "smtp.webmail.com";
        //smtpClient.Host = "mail.brandoitte.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential("stsservices16@gmail.com", "@123456#");       
        //smtpClient.UseDefaultCredentials = false;        
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //smtpClient.ServicePoint.MaxIdleTime = 1;        
        smtpClient.Send(oMessage);
        
 
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Send Mail</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    Email sent!
        
    </div>
    </form>
</body>
</html>
