package views;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class editPanel extends JPanel{

	private Image image;
	
	
	public  editPanel() {
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/회원수정.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);
			
		
		JTextField nameField = new JTextField();
		JTextField passwordField = new JTextField();
		JTextField passwordCheckField = new JTextField();
		JTextField birthField = new JTextField();
		JTextField emailField = new JTextField();
		JTextField centerPhoneField = new JTextField();
		JTextField lastPhoneField = new JTextField();
		JTextField addressField = new JTextField();
		JTextField zipCodeField = new JTextField();
		
	
		JButton addressButton = new JButton("주소찾기");
		JButton backButton = new JButton("뒤로가기");
		JButton signUpButton = new JButton("회원수정");
		
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
		signUpButton.setBounds(50, 560, 100, 40);
		
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
		add(signUpButton);
		
		
		backButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	setVisible(false);
		    }  
		}); 
		
	}
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, null);
		setOpaque(false);
	}
}
