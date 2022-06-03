package controls;
import java.util.Properties;

import javax.mail.*;
import javax.mail.internet.*;

public class test {

	
	public void naverMailSend() {
        String host = "smtp.naver.com"; 	
        String user = "zzuni3423@naver.com"; 
        String password = "wpsxmfks3135!";       

        // SMTP 서버 정보를 설정한다.
        Properties props = new Properties();
        props.put("mail.smtp.host", host);
        props.put("mail.smtp.port", 587);
        props.put("mail.smtp.auth", "true");
        
        Session session = Session.getDefaultInstance(props, new javax.mail.Authenticator() {
            	protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(user, password);
            }
        });

        try {
            MimeMessage message = new MimeMessage(session);
            message.setFrom(new InternetAddress(user));
            message.addRecipient(Message.RecipientType.TO, new InternetAddress("zzuni3423@naver.com"));

            // 메일 제목
            message.setSubject("KTKO SMTP TEST1111");

            // 메일 내용
            message.setText("KTKO Success!!");

            // send the message
            Transport.send(message);
            System.out.println("Success Message Send");

        } catch (MessagingException e) {
            e.printStackTrace();
        }
        
    }
	
}
