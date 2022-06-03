package controls;

import java.util.Date;
import java.util.Properties;
import java.util.Random;

import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class SendEmail {

	public int randomNumber;
	
	public void sendEmail(String email) {
		Random random = new Random(); 
		int bound = 100000;
		randomNumber = random.nextInt(bound);
		
		Properties p = System.getProperties();
        p.put("mail.smtp.starttls.enable", "true");
        p.put("mail.smtp.host", "smtp.naver.com");
        p.put("mail.smtp.auth", "true");
        p.put("mail.smtp.port", "587");
        p.put("mail.smtp.ssl.protocols", "TLSv1.2");
 
        Authenticator auth = new MyAuthentication();
        Session session = Session.getDefaultInstance(p, auth);
        MimeMessage msg = new MimeMessage(session);
 
        try {
            msg.setSentDate(new Date());
            InternetAddress from = new InternetAddress();
            
            from = new InternetAddress("zzuni3423<zzuni3423@naver.com>");
            msg.setFrom(from);
 
            InternetAddress to = new InternetAddress(email);
            msg.setRecipient(Message.RecipientType.TO, to);
 
            msg.setSubject("엔샵 인증번호", "UTF-8");
            msg.setText("인증번호 : " + randomNumber, "UTF-8");
            msg.setHeader("content-Type", "text/html");
 
            javax.mail.Transport.send(msg);
        } catch (AddressException addr_e){
            addr_e.printStackTrace();
        } catch (MessagingException msg_e){
            msg_e.printStackTrace();
        }
    }

	
	class MyAuthentication extends Authenticator {
		 
	    PasswordAuthentication account;
	 
	    public MyAuthentication(){
	        String id = "zzuni3423";
	        String pw = "wpsxmfks3135!";
	        account = new PasswordAuthentication(id, pw);
	    }
	 
	    public PasswordAuthentication getPasswordAuthentication(){
	        return account;
	    }
	}
}
