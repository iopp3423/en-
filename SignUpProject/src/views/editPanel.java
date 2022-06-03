package views;

import java.awt.Desktop;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

import controls.Controller;

public class editPanel extends JPanel{

	private Image image;
	public Controller control;
	public JTextField nameField; 
	public JTextField passwordField;
	public JTextField passwordCheckField;
	public JTextField birthField;
	public JTextField emailField;
	public JTextField centerPhoneField;
	public JTextField lastPhoneField ;
	public JTextField addressField;
	public JTextField zipCodeField;
	
	
	public  editPanel(Controller control) {
		this.control = control;
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/회원수정.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);
			
		
		nameField = new JTextField();
		passwordField = new JTextField();
		passwordCheckField = new JTextField();
		birthField = new JTextField();
		emailField = new JTextField();
		centerPhoneField = new JTextField();
		lastPhoneField = new JTextField();
		addressField = new JTextField();
		zipCodeField = new JTextField();
		
	
		JButton addressButton = new JButton("주소찾기");
		JButton backButton = new JButton("뒤로가기");
		JButton reviseButton = new JButton("회원수정");
		
		String[] phoneNumber = {"010", "011", "016", "0503"}; 
		String[] adress = {"@gmail.com", "@naver.com", "@daum.net", "@cyworld.com", "@hanmail.net", "@kakao.com", "@yahoo.com"};
		
		JComboBox emailBox = new JComboBox(adress);
		JComboBox phoneBox = new JComboBox(phoneNumber);
		
		
		
		nameField.setBounds(175, 65, 230, 35);		
		passwordField.setBounds(175, 130, 230, 40);
		passwordCheckField.setBounds(175, 190, 230, 40);
		birthField.setBounds(175, 260, 230, 40);
		emailField.setBounds(175, 330, 100, 38);
		centerPhoneField.setBounds(260, 380, 80, 40);
		lastPhoneField.setBounds(350, 380, 80, 40);
		addressField.setBounds(175, 430, 300, 40);
		zipCodeField.setBounds(175, 480, 100, 40);
		
		addressButton.setBounds(280, 480, 100, 40);
		backButton.setBounds(50, 10, 100, 35);
		reviseButton.setBounds(50, 560, 100, 40);
		
		phoneBox.setBounds(175, 385, 80, 40);
		emailBox.setBounds(280, 330, 150, 38);
		
		
		add(nameField);
		add(passwordField);
		add(passwordCheckField);
		add(birthField);
		add(emailField);
		add(centerPhoneField);
		add(lastPhoneField);
		add(addressField);
		add(zipCodeField);
		
		add(phoneBox);
		add(emailBox);
		
		add(addressButton);
		add(backButton);
		add(reviseButton);
		
		
		addressButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	if (Desktop.isDesktopSupported()) {
		            Desktop desktop = Desktop.getDesktop();
		            try {
		                URI uri = new URI("https://www.juso.go.kr/openIndexPage.do");
		                desktop.browse(uri);
		            } catch (IOException ex) {
		                ex.printStackTrace();
		            } catch (URISyntaxException ex) {
		                ex.printStackTrace();
		            }
		    }
		    }  
		}); 
		
		backButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	setVisible(false);
		    }  
		}); 
		
		reviseButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그인오류.png")); // 바로 가져오면 gif가져와
				ImageIcon signFailImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
		    	ImageIcon signIcon = new ImageIcon(MainPanel.class.getResource("/image/회원가입완료.png"));
				ImageIcon signupImage = new ImageIcon(signIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
				
		    	String errorCheck = control.reviseMember(nameField.getText(), passwordField.getText(), passwordCheckField.getText(), birthField.getText(), 
	    				emailField.getText() , centerPhoneField.getText() + 
	    				lastPhoneField.getText(), addressField.getText(), zipCodeField.getText());
	    		
	    		switch(errorCheck) {    
	    		case "0": // 비밀번호 일치 류 
	    			JOptionPane.showMessageDialog(null, "이름을 잘못 입력하셨습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			passwordField.setText("");
	    			passwordCheckField.setText("");		
	    		case "1": // 비밀번호 일치 류 
	    			JOptionPane.showMessageDialog(null, "비밀번호가 일치하지 않습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			passwordField.setText("");
	    			passwordCheckField.setText("");
	    			break;	
	    		case "2":
	    			JOptionPane.showMessageDialog(null, "비밀번호를 잘못 입력하셨습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			passwordField.setText("");
	    			passwordCheckField.setText("");
	    			break;
	    		case "3":
	    			JOptionPane.showMessageDialog(null, "생년월일을 잘못 입력하셨습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			birthField.setText("");
	    			break;
	    		case "4":
	    			JOptionPane.showMessageDialog(null, "이메일을 잘못 입력하셨습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			emailField.setText("");
	    			break;

	    		case "5":
	    			JOptionPane.showMessageDialog(null, "전화번호를 잘못 입력하셨습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			centerPhoneField.setText("");
	    			lastPhoneField.setText("");
	    			break;
	    		case "6":
	    			JOptionPane.showMessageDialog(null, "이름을 잘못 입력하셨습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signFailImage); // id 중복체크 메시지 
	    			nameField.setText("");
	    			break;
	    		
	    		case "7":
		    	JOptionPane.showMessageDialog(null, "수정되었습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signupImage);
		    	setVisible(false);
		    	break;
	    		}
		    }  
		}); 
		
	}
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, null);
		setOpaque(false);
	}
}
