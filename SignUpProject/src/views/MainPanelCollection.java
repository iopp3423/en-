package views;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

import utility.Constants;

public class MainPanelCollection{

	JFrame searchIdFrame;
	JFrame searchPwFrame;
	searchIdPanel idPanel;
	searchPwPanel pwPanel;
	Image image;
	
	public MainPanelCollection()// 계정이름, 비밀번호 잊으셨나요 클릭 시 나오는 프레임
	{
		searchIdFrame = new JFrame();
		searchPwFrame = new JFrame();
		idPanel = new searchIdPanel();
		pwPanel = new searchPwPanel();
		
		
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

		JLabel nameLabel = new JLabel("이름");
		JLabel emailLabel = new JLabel("이메일");
		JLabel emailInputLabel = new JLabel("인증번호");
		JTextField nameField = new JTextField();
		JTextField emailField = new JTextField();
		JTextField emailNumberField = new JTextField();
		JButton sendEmailButton = new JButton("인증번호 받기");
		JButton checkEmailButton = new JButton("확인");
		JButton exitButton = new JButton("OK");
		
		public searchIdPanel() {
			
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/사진2.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(500, 400, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);

		emailInputLabel.setBounds(60, 200, 150, 50);
		nameLabel.setBounds(70, 50, 150, 50);
		emailLabel.setBounds(70, 100, 150, 50);
		
		nameField.setBounds(110, 50, 300, 50);
		emailField.setBounds(110, 100, 200, 50);
		emailNumberField.setBounds(110, 200, 200, 50);
		
		sendEmailButton.setBounds(310, 100, 100, 50);
		exitButton.setBounds(200, 300, 100, 50);
		checkEmailButton.setBounds(310, 200, 100, 50);
		
		add(exitButton);
		add(sendEmailButton);
		add(checkEmailButton);
		
		add(nameField);
		add(emailField);
		add(emailNumberField);
		
		add(nameLabel);
		add(emailLabel);
		add(emailInputLabel);
		
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
	
	class searchPwPanel extends JPanel{ // 비밀번호를 잊으셨나요 클릭 시 프레임에 붙이는 패널 
		Image image;

		JLabel idLabel = new JLabel("아이디");
		JLabel emailLabel = new JLabel("이메일");
		JLabel emailInputLabel = new JLabel("인증번호");
		JTextField nameField = new JTextField();
		JTextField emailField = new JTextField();
		JTextField emailNumberField = new JTextField();
		JButton sendEmailButton = new JButton("인증번호 받기");
		JButton checkEmailButton = new JButton("확인");
		JButton exitButton = new JButton("OK");
		
		public searchPwPanel() {
		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/사진2.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(500, 400, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);
	
		emailInputLabel.setBounds(60, 200, 150, 50);
		idLabel.setBounds(70, 50, 150, 50);
		emailLabel.setBounds(70, 100, 150, 50);
		
		nameField.setBounds(110, 50, 300, 50);
		emailField.setBounds(110, 100, 200, 50);
		emailNumberField.setBounds(110, 200, 200, 50);
		
		sendEmailButton.setBounds(310, 100, 100, 50);		
		exitButton.setBounds(200, 300, 100, 50);
		checkEmailButton.setBounds(310, 200, 100, 50);
		
		add(exitButton);
		add(sendEmailButton);
		add(checkEmailButton);
		
		add(nameField);
		add(emailField);
		add(emailNumberField);
		
		add(idLabel);
		add(emailLabel);
		add(emailInputLabel);
		
		
		
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
}
