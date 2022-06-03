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
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import controls.controller;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

public class MainPanel extends JPanel{
	
	private Image image;
	private MainPanelCollection searchFrame;
	private SignUpPanel signUpPanel;
	private ControllerPanel controllerPanel;
	private editPanel edit;
	private controller control;
	
	public MainPanel(Image image, JFrame mainFrame) {
		this.image = image;
		
		control = new controller();
		searchFrame = new MainPanelCollection();
		signUpPanel = new SignUpPanel(control); // 회원가입 화면 
		edit = new editPanel();
		controllerPanel = new ControllerPanel(edit, control);
		
		mainFrame.add(edit);
		mainFrame.add(signUpPanel);
		mainFrame.add(controllerPanel);

		edit.setVisible(false);
		controllerPanel.setVisible(false);
		signUpPanel.setVisible(false);
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);	
		
		
		JTextField idInput = new JTextField();
		JPasswordField pwInput = new JPasswordField();
		JLabel idLabel = new JLabel("계정이름");
		JLabel pwLabel = new JLabel("비밀번호");
		JButton login = new JButton("로그인");
		JLabel signUp = new JLabel("아직 계정이 없으신가요? 지금 가입하세요!");
		JLabel searchId = new JLabel("계정이름을 잊으셨나요?");
		JLabel searchPw = new JLabel("비밀번호를 잊으셨나요?");
		
		setFontAndSize(idLabel, 14);
		setFontAndSize(pwLabel, 14);
		setFontAndSize(searchId, 12);
		setFontAndSize(searchPw, 12);
		setFontAndSize(signUp, 12);
				
		
		
		idLabel.setBounds(50, 180, 200, 40);
		pwLabel.setBounds(50, 250, 200, 40);
		
		idInput.setBounds(50,210,230,40);
		pwInput.setBounds(50,280,230,40);
		
		signUp.setBounds(50, 370, 280, 40);
		searchId.setBounds(50, 400, 200, 40);
		searchPw.setBounds(50, 420, 200, 40);
		
		login.setBounds(210, 320, 70, 40);
		
		
		add(idLabel);
		add(pwLabel);
		
		add(searchId);
		add(searchPw);
		
		add(login);
		add(signUp);
		
		add(pwInput);
		add(idInput);
		
		
		
		login.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    { 
		    	if(control.loginControl(idInput.getText(), pwInput.getPassword())) {
			    	idInput.setText("");
			    	pwInput.setText("");
		    		controllerPanel.setVisible(true);
		    	} 	
		    	else {
		    		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그인오류.png"));
					ImageIcon signupImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
			    	JOptionPane.showMessageDialog(null, "일치하는 계정이 없습니다.", "Message",JOptionPane.PLAIN_MESSAGE, signupImage);
			    	idInput.setText("");
			    	pwInput.setText("");
		    	}
		    }  
		}); 
		
		signUp.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	signUpPanel.setVisible(true);
		    	
		    }  
		}); 
		
		searchId.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	searchFrame.searchIdFrame.setVisible(true);
		    }  
		}); 
		searchPw.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e)  
		    {  
		    	searchFrame.searchPwFrame.setVisible(true);
		    }  
		});
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, null);
		setOpaque(false);
	}
	
	private void setFontAndSize(JLabel label, int size) {
		
		label.setFont(new Font("Serif", Font.BOLD, size));
		label.setForeground(Color.WHITE);	
	}
	
}
