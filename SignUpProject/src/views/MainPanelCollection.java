package views;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

import controls.Controller;
import controls.SendEmail;
import utility.Constants;

public class MainPanelCollection{

	public JFrame searchIdFrame;
	public JFrame searchPwFrame;
	public searchIdPanel idPanel;
	public searchPwPanel pwPanel;
	private Image image;
	
	
	public MainPanelCollection(Controller control)// 계정이름, 비밀번호 잊으셨나요 클릭 시 나오는 프레임
	{
		SendEmail send = new SendEmail();
		searchIdFrame = new JFrame();
		searchPwFrame = new JFrame();
		idPanel = new searchIdPanel(control, send);
		pwPanel = new searchPwPanel(control, send);
		
		
		searchIdFrame.setSize(500,400);
		searchIdFrame.setPreferredSize(new Dimension(500,400));	
		searchIdFrame.setLocationRelativeTo(null); // 화면 나오는 위치
		searchIdFrame.setResizable(false);
		searchIdFrame.setVisible(false);
		
		searchPwFrame.setSize(500,400);
		searchPwFrame.setPreferredSize(new Dimension(500,400));	
		searchPwFrame.setLocationRelativeTo(null); // 화면 나오는 위치
		searchPwFrame.setResizable(false);
		searchPwFrame.setVisible(false);
		

		searchPwFrame.add(pwPanel);
		searchIdFrame.add(idPanel);
		
		searchIdFrame.pack();
		searchPwFrame.pack();
	}
	
	public class searchIdPanel extends JPanel{ // 계정이름을 잊으셨나요 클릭 시 프레임에 붙이는 패널 

		public JLabel nameLabel = new JLabel("이름");
		public JLabel emailLabel = new JLabel("이메일");
		public JLabel emailInputLabel = new JLabel("인증번호");
		
		public JTextField nameField = new JTextField();
		public JTextField emailField = new JTextField();
		public JTextField emailNumberField = new JTextField();
		
		public JButton getEmailButton = new JButton("인증번호 받기");
		public JButton checkEmailButton = new JButton("확인");
		public JButton exitButton = new JButton("OK");
		private Controller control;
		private SendEmail send;
		
		public searchIdPanel(Controller control, SendEmail send) {
			
			
		this.send = send;
		this.control = control;
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/찾기.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(500, 400, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);

		setFontAndSize(nameLabel,14);
		setFontAndSize(emailLabel,14);
		setFontAndSize(emailInputLabel,14);
		
		emailInputLabel.setVisible(false);
    	emailNumberField.setVisible(false);
    	checkEmailButton.setVisible(false);
    	
		emailInputLabel.setBounds(55, 200, 150, 50);
		nameLabel.setBounds(65, 50, 150, 50);
		emailLabel.setBounds(65, 100, 150, 50);
		
		nameField.setBounds(110, 50, 300, 50);
		emailField.setBounds(110, 100, 200, 50);
		emailNumberField.setBounds(110, 200, 200, 50);
		
		getEmailButton.setBounds(310, 100, 100, 50);
		exitButton.setBounds(200, 300, 100, 50);
		checkEmailButton.setBounds(310, 200, 100, 50);
		
		add(exitButton);
		add(getEmailButton);
		add(checkEmailButton);
		
		add(nameField);
		add(emailField);
		add(emailNumberField);
		
		add(nameLabel);
		add(emailLabel);
		add(emailInputLabel);
		
		getEmailButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	
		    	if(!control.checkData(idPanel.nameField.getText(), idPanel.emailField.getText())) { // 회원목록에 없는 이름이면 
		    		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그인오류.png"));
					ImageIcon signupImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
			    	JOptionPane.showMessageDialog(null, "일치하는 계정이 없습니다.", "Message", JOptionPane.PLAIN_MESSAGE, signupImage);
		    	}
		    	
		    	else {
			    	send.sendEmail(control.members.get(0).getEmail()); // 입력한 이메일로 메일 발송
			    	emailInputLabel.setVisible(true);
			    	emailNumberField.setVisible(true);
			    	checkEmailButton.setVisible(true);				    	
		    	}	    	
		    }  
		}); 
		
		
		checkEmailButton.addMouseListener(new MouseAdapter(){  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	
		    	if(send.randomNumber == Integer.parseInt(emailNumberField.getText())) {
		    		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/회원가입완료.png"));
					ImageIcon signupImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
			    	JOptionPane.showMessageDialog(null, "Id : " + control.searchId.get(0).getId(), "Message", JOptionPane.PLAIN_MESSAGE, signupImage);
		    	}
		    	else {
		    		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그인오류.png"));
					ImageIcon signupImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
			    	JOptionPane.showMessageDialog(null, "인증번호가 일치하지 않습니다.", "Message", JOptionPane.PLAIN_MESSAGE, signupImage);
		    	}
		    }  
		}); 
		
		
		exitButton.addMouseListener(new MouseAdapter(){  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	searchIdFrame.setVisible(false);
		    }  
		}); 
		
		}
		
		public void paintComponent(Graphics g) {
			g.drawImage(image, 0, 0, null);
			setOpaque(false);
		}
	}
	
	public class searchPwPanel extends JPanel{ // 비밀번호를 잊으셨나요 클릭 시 프레임에 붙이는 패널 
		Image image;

		public JLabel idLabel = new JLabel("아이디");
		public JLabel emailLabel = new JLabel("이메일");
		public JLabel emailInputLabel = new JLabel("인증번호");
		
		public JTextField nameField = new JTextField();
		public JTextField emailField = new JTextField();
		public JTextField emailNumberField = new JTextField();		
		
		public JButton getEmailButton = new JButton("인증번호 받기");
		public JButton checkEmailButton = new JButton("확인");
		public JButton exitButton = new JButton("OK");
		
		private SendEmail send;
		private Controller control;
		
		public searchPwPanel(Controller control, SendEmail send) {
		
		this.send = send;
		this.control = control;	
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/찾기.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(500, 400, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);
		
		setFontAndSize(idLabel,14);
		setFontAndSize(emailLabel,14);
		setFontAndSize(emailInputLabel,14);
		
		emailInputLabel.setVisible(false);
    	emailNumberField.setVisible(false);
    	checkEmailButton.setVisible(false);
	
		emailInputLabel.setBounds(55, 200, 150, 50);
		idLabel.setBounds(65, 50, 150, 50);
		emailLabel.setBounds(65, 100, 150, 50);
		
		nameField.setBounds(110, 50, 300, 50);
		emailField.setBounds(110, 100, 200, 50);
		emailNumberField.setBounds(110, 200, 200, 50);
		
		getEmailButton.setBounds(310, 100, 100, 50);		
		exitButton.setBounds(200, 300, 100, 50);
		checkEmailButton.setBounds(310, 200, 100, 50);
		
		add(exitButton);
		add(getEmailButton);
		add(checkEmailButton);
		
		add(nameField);
		add(emailField);
		add(emailNumberField);
		
		add(idLabel);
		add(emailLabel);
		add(emailInputLabel);
		
		
		getEmailButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	emailInputLabel.setVisible(true);
		    	emailNumberField.setVisible(true);
		    	checkEmailButton.setVisible(true);
		    }  
		}); 
		
		exitButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	searchPwFrame.setVisible(false);
		    }  
		}); 
			

		}
		public void paintComponent(Graphics g) {
			g.drawImage(image, 0, 0, null);
			setOpaque(false);
		}
		
	}
	private void setFontAndSize(JLabel label, int size) {
		
		label.setFont(new Font("Serif", Font.BOLD, size));
		label.setForeground(Color.WHITE);

	}
}
