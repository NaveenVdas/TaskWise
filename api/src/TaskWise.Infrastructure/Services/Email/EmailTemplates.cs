namespace TaskWise.Infrastructure.Services.Email;

public static class EmailTemplates
{
    public static string GetInviteEmailHtml(string recipientName, string inviteUrl)
    {
        return $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Invitation to TaskWise</title>
    <style>
        body {{
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
            line-height: 1.6;
            color: #333333;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f4f4f4;
        }}
        .container {{
            background-color: #ffffff;
            border-radius: 8px;
            padding: 40px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
        .header {{
            text-align: center;
            margin-bottom: 30px;
        }}
        .logo {{
            font-size: 32px;
            font-weight: bold;
            color: #4a90e2;
            margin-bottom: 10px;
        }}
        .content {{
            margin-bottom: 30px;
        }}
        .button {{
            display: inline-block;
            padding: 14px 28px;
            background-color: #4a90e2;
            color: #ffffff;
            text-decoration: none;
            border-radius: 5px;
            font-weight: bold;
            text-align: center;
            margin: 20px 0;
        }}
        .button:hover {{
            background-color: #357abd;
        }}
        .button-container {{
            text-align: center;
            margin: 30px 0;
        }}
        .footer {{
            margin-top: 40px;
            padding-top: 20px;
            border-top: 1px solid #e0e0e0;
            font-size: 12px;
            color: #666666;
            text-align: center;
        }}
        .link {{
            color: #4a90e2;
            word-break: break-all;
        }}
        .warning {{
            background-color: #fff3cd;
            border-left: 4px solid #ffc107;
            padding: 12px;
            margin: 20px 0;
            border-radius: 4px;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <div class=""logo"">TaskWise</div>
        </div>
        
        <div class=""content"">
            <h2>You've been invited!</h2>
            
            <p>Hello {recipientName},</p>
            
            <p>You have been invited to join TaskWise, a powerful task management platform designed to help teams collaborate and stay organized.</p>
            
            <p>To get started, please click the button below to accept your invitation and set up your account:</p>
            
            <div class=""button-container"">
                <a href=""{inviteUrl}"" class=""button"">Accept Invitation</a>
            </div>
            
            <p>Or copy and paste this link into your browser:</p>
            <p class=""link"">{inviteUrl}</p>
            
            <div class=""warning"">
                <strong>⚠️ Important:</strong> This invitation link will expire in 24 hours. Please accept the invitation before it expires.
            </div>
            
            <p>If you did not expect this invitation, you can safely ignore this email.</p>
            
            <p>Welcome aboard!</p>
            
            <p>Best regards,<br>The TaskWise Team</p>
        </div>
        
        <div class=""footer"">
            <p>This is an automated email. Please do not reply to this message.</p>
            <p>&copy; {DateTime.UtcNow.Year} TaskWise. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";
    }

    public static string GetInviteEmailPlainText(string recipientName, string inviteUrl)
    {
        return $@"
TaskWise - Invitation

Hello {recipientName},

You have been invited to join TaskWise, a powerful task management platform designed to help teams collaborate and stay organized.

To get started, please click the link below to accept your invitation and set up your account:

{inviteUrl}

IMPORTANT: This invitation link will expire in 24 hours. Please accept the invitation before it expires.

If you did not expect this invitation, you can safely ignore this email.

Welcome aboard!

Best regards,
The TaskWise Team

---
This is an automated email. Please do not reply to this message.
© {DateTime.UtcNow.Year} TaskWise. All rights reserved.
";
    }
}

