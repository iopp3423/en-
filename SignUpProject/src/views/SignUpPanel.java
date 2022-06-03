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
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class SignUpPanel extends JPanel{

	private Image image;

	
	public SignUpPanel() {

		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/회원가입.png"));
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);	
		
		JTextField nameField = new JTextField();
		JTextField idField = new JTextField();
		JTextField passwordField = new JTextField();
		JTextField passwordCheckField = new JTextField();
		JTextField birthField = new JTextField();
		JTextField emailField = new JTextField();
		JTextField centerPhoneField = new JTextField();
		JTextField lastPhoneField = new JTextField();
		JTextField addressField = new JTextField();
		JTextField zipCodeField = new JTextField();
		
		JLabel nameLabel = new JLabel("이름");
		JLabel idLabel = new JLabel("ID");
		JLabel passwordLabel = new JLabel("PW");
		JLabel passwordCheckLabel = new JLabel("PWCheck");
		JLabel birthLabel = new JLabel("생년월일");
		JLabel emailLabel = new JLabel("이메일");
		JLabel phoneLabel = new JLabel("전화번호");
		JLabel addressLabel = new JLabel("<html>"+"주소"+"<br>"+"<br>"+"우편번호");
		
		JLabel nameGuide = new JLabel("한글 2~4자, 영어 2~10자까지 가능합니다.");
		JLabel idGuide = new JLabel("영어, 숫자포함(7~14)");
		JLabel passwordGuide = new JLabel("영어, 숫자포함(7~14)");
		JLabel birthGuide = new JLabel("ex)990820");
		
		JButton idCheckButton = new JButton("아이디 중복체크");
		JButton addressButton = new JButton("주소찾기");
		JButton backButton = new JButton("뒤로가기");
		JButton signUpButton = new JButton("회원가입");
		
		String[] phoneNumber = {"010", "011", "016", "0503"}; 
		String[] adress = {"gmail.com", "naver.com", "daum.net", "cyworld.com", "hanmail.net", "kakao.com", "yahoo.com"};
		
		JComboBox emailBox = new JComboBox(adress);
		JComboBox phoneBox = new JComboBox(phoneNumber);
		
		
		// 버튼설정
		idCheckButton.setBounds(340, 150, 100, 40);
		addressButton.setBounds(250, 562, 100, 40);
		backButton.setBounds(30, 20, 100, 40);
		signUpButton.setBounds(30, 630, 150, 40);
		idCheckButton.setFocusable(false);
		
		//콤보박스 설정
		phoneBox.setBounds(140, 460, 80, 40);
		emailBox.setBounds(340, 398, 200, 50);
		
		///////////////입력 관련 설정 가로위치, 세로위치, 가로크기, 세로크기 
		nameField.setBounds(140, 80, 200, 40);
		idField.setBounds(140, 150, 200, 40);
		passwordField.setBounds(140, 220, 200, 40);
		passwordCheckField.setBounds(140, 290, 200, 40);
		birthField.setBounds(140, 340, 200, 40);
		emailField.setBounds(140, 398, 200, 38);
		centerPhoneField.setBounds(220, 460, 80, 40);
		lastPhoneField.setBounds(300, 460, 80, 40);
		addressField.setBounds(140, 518, 300, 40);
		zipCodeField.setBounds(140, 562, 100, 40);
		
		////////////안내 문 // 글씨사이즈, 가로위치, 세로위치, 가로크기, 세로크기
		setLabel(nameLabel, 30, 30, 80, 100, 50);
		setLabel(idLabel, 30, 30, 148, 100, 50);
		setLabel(passwordLabel, 30, 30, 220, 100, 50);
		setLabel(passwordCheckLabel, 20, 30, 293, 100, 34);
		setLabel(birthLabel, 25, 30, 338, 100, 50);
		setLabel(emailLabel, 25, 30, 403, 100, 30);
		setLabel(phoneLabel, 25, 30, 460, 100, 40);
		setLabel(addressLabel, 20, 40, 520, 100, 80);
		
		//////////입력 관련 가이드, 라벨, 글씨사이즈, 가로위치, 세로위치, 가로크기, 세로크기 
		setLabel(nameGuide, 10, 150, 110, 200, 40);
		setLabel(idGuide, 10, 150, 180, 200, 40);
		setLabel(passwordGuide, 10, 150, 250, 200, 40);
		setLabel(birthGuide, 10, 150, 368, 200, 40);
		
		
		add(nameField);
		add(idField);
		add(passwordField);
		add(passwordCheckField);
		add(birthField);
		add(emailField);
		add(centerPhoneField);
		add(lastPhoneField);
		add(addressField);
		add(zipCodeField);
				
		add(nameLabel);
		add(idLabel);
		add(passwordLabel);
		add(passwordCheckLabel);
		add(birthLabel);
		add(emailLabel);
		add(phoneLabel);
		add(addressLabel);	
		
		add(nameGuide);
		add(idGuide);
		add(passwordGuide);
		add(birthGuide);
		
		add(phoneBox);
		add(emailBox);
		
		add(idCheckButton);
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
		
		signUpButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/회원가입완료.png"));
				ImageIcon signupImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
		    	JOptionPane.showMessageDialog(null, "환영합니다.", "Message",JOptionPane.PLAIN_MESSAGE, signupImage);
		    	setVisible(false);		    	
		    }  
		}); 
		
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, null);
		setOpaque(false);
	}
	
	private void setLabel(JLabel label, int size, int width, int height, int widthSize, int heightSize) {
		
		label.setBounds(width, height,widthSize,heightSize);
		label.setFont(new Font("bold", Font.BOLD, size));
		label.setHorizontalAlignment(JLabel.CENTER);
		label.setForeground(Color.WHITE);
		label.setOpaque(false);	
	}
}
