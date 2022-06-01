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
	Image image;
	
	public MainPanelCollection()
	{
		searchIdFrame = new JFrame();
		searchPwFrame = new JFrame();
		
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
		
		searchIdPanel();
		searchPwPanel();
		searchIdFrame.pack();
		searchPwFrame.pack();
	}
	
	public void searchIdPanel() { // 계정이름을 잊으셨나요 클릭 시 프레임에 붙이는 패널 
		JPanel panel = new JPanel();
		JLabel nameLabel = new JLabel("이름");
		JLabel emailLabel = new JLabel("이메일");
		JTextField nameField = new JTextField();
		JTextField emailField = new JTextField();
		JButton sendEmailButton = new JButton("인증번호 받기");
		JButton exitButton = new JButton("OK");
		
		panel.setLayout(null);
		
		nameLabel.setBounds(70, 50, 150, 50);
		emailLabel.setBounds(70, 100, 150, 50);
		
		nameField.setBounds(110, 50, 300, 50);
		emailField.setBounds(110, 100, 200, 50);
		sendEmailButton.setBounds(310, 100, 100, 50);
		exitButton.setBounds(200, 300, 100, 50);
		
		panel.add(exitButton);
		panel.add(sendEmailButton);
		panel.add(nameField);
		panel.add(emailField);
		panel.add(nameLabel);
		panel.add(emailLabel);
		
		exitButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	searchIdFrame.setVisible(false);
		    }  
		}); 
			
		searchIdFrame.add(panel);
	}
	
	
	public void searchPwPanel() {
		Image image;
		JPanel panel = new JPanel();
		JLabel idLabel = new JLabel("아이디");
		JLabel emailLabel = new JLabel("이메일");
		JTextField nameField = new JTextField();
		JTextField emailField = new JTextField();
		JButton sendEmailButton = new JButton("인증번호 받기");
		JButton exitButton = new JButton("OK");
		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/사진2.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(500, 400, Image.SCALE_SMOOTH)).getImage();

		panel.setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		panel.setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		panel.setLayout(null);
		
		panel.setOpaque(false);
		
		idLabel.setBounds(70, 50, 150, 50);
		emailLabel.setBounds(70, 100, 150, 50);
		
		nameField.setBounds(110, 50, 300, 50);
		emailField.setBounds(110, 100, 200, 50);
		sendEmailButton.setBounds(310, 100, 100, 50);
		exitButton.setBounds(200, 300, 100, 50);
		
		panel.add(exitButton);
		panel.add(sendEmailButton);
		panel.add(nameField);
		panel.add(emailField);
		panel.add(idLabel);
		panel.add(emailLabel);
		
		exitButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	searchPwFrame.setVisible(false);
		    }  
		}); 
			
		searchPwFrame.add(panel);
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, null);
		
	}
}
