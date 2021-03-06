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
import utility.Constants;

public class ControllerPanel extends JPanel{

	private Image image;
	private JFrame deleteFrame;
	private JPanel deletePanel;
	
	public ControllerPanel(EditPanel edit, Controller control) {
		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/메뉴.png"));	
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);
		
		JButton editButton = new JButton(new ImageIcon(new ImageIcon("/image/edit.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		JButton setButton = new JButton(new ImageIcon(new ImageIcon("/image/set.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		JButton logoutButton = new JButton(new ImageIcon(new ImageIcon("/image/logout.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		JButton deleteButton = new JButton(new ImageIcon(new ImageIcon("/image/delete.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		
		deleteFrame = new JFrame();		
		deletePanel = new deletePanel(control, this);
		
		deleteFrame.setSize(500,400);
		deleteFrame.setPreferredSize(new Dimension(500,400));	
		deleteFrame.setLocationRelativeTo(null); // 화면 나오는 위치
		deleteFrame.setResizable(false);
		deleteFrame.setVisible(false);
		
		deleteFrame.add(deletePanel);
		deleteFrame.pack();
		
		setButtonImage(editButton);
		setButtonImage(setButton);
		setButtonImage(logoutButton);
		setButtonImage(deleteButton);
		

		editButton.setBounds(120, 57, 240, 400);
		setButton.setBounds(380, 57, 240, 400);
		logoutButton.setBounds(640, 57, 240, 400);
		deleteButton.setBounds(900, 57, 240, 400);
		
		//editButton.setSelectedIcon(new ImageIcon(imageIcon.getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		//editButton.setPressedIcon(new ImageIcon(imageIcon.getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
    	
		add(editButton);
		add(setButton);
		add(logoutButton);
		add(deleteButton);
		
		//editButton.setIcon(new ImageIcon("/image/set.png"));
    
		
		editButton.addMouseListener(new MouseAdapter()  
		{  

		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	    	
		    	edit.nameField.setText(control.loginId.get(0).getName());
		    	edit.passwordField.setText(control.loginId.get(0).getPassword());
		    	edit.passwordCheckField.setText(control.loginId.get(0).getPassword());
		    	edit.birthField.setText(control.loginId.get(0).getBirth());
		    	edit.emailField.setText(control.loginId.get(0).getEmail());
		    	edit.centerPhoneField.setText(control.loginId.get(0).getCallNumber().substring(0, 4));
		    	edit.lastPhoneField.setText(control.loginId.get(0).getCallNumber().substring(4));
		    	edit.addressField.setText(control.loginId.get(0).getAddress());
		    	edit.zipCodeField.setText(control.loginId.get(0).getZipCode());
		    	edit.setVisible(true);	    	
		    }   
		}); 
		setButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseEntered(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		       
		    }

		    public void mouseExited(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        
		    }
		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
		    	
		    }   
		}); 
		
		
		logoutButton.addMouseListener(new MouseAdapter()  
		{  
			
			public void mouseClicked(MouseEvent e)  
		    {  				
			
			ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그아웃안내.png"));
			ImageIcon logoutImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
			int input = JOptionPane.showConfirmDialog(null, "로그아웃 하시겠습니까?", "안내메시지", JOptionPane.YES_NO_OPTION, JOptionPane.QUESTION_MESSAGE, logoutImage);
				if(input == 0) {
					setVisible(false);
				}
		    }
		}); 
		
	
		deleteButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseEntered(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		       
		    }

		    public void mouseExited(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        
		    }
		    public void mouseClicked(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
		    	deleteFrame.setVisible(true);
		    }   
		}); 
	
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(image, 0, 0, null);
		setOpaque(false);
	}
	
	
	private void setButtonImage(JButton button) {
		button.setBorderPainted(false); 
		button.setFocusPainted(false); 
		button.setContentAreaFilled(false); 
	}
	
	
	public class deletePanel extends JPanel{
		
		private Image deleteimage;
		private Controller control;
		private ControllerPanel controlPanel;
		
		public deletePanel(Controller control, ControllerPanel controlPanel) {
			
		ImageIcon deleteIcon = new ImageIcon(MainPanel.class.getResource("/image/삭제.png"));	
		deleteimage = new ImageIcon(deleteIcon.getImage().getScaledInstance(500, 400, Image.SCALE_SMOOTH)).getImage();
		
		setSize(new Dimension(deleteimage.getWidth(null), deleteimage.getHeight(null)));
		setPreferredSize(new Dimension(deleteimage.getWidth(null), deleteimage.getHeight(null)));
		setLayout(null);			
		
		JLabel label = new JLabel("회원탈퇴 하시겠습니까?");
		//JTextField passwordField = new JTextField();
	
		ImageIcon noIcon = new ImageIcon(ControllerPanel.class.getResource("/image/no.png"));	
		JButton noButton = new JButton(new ImageIcon(noIcon.getImage().getScaledInstance(80, 90, Image.SCALE_SMOOTH)));
		
		ImageIcon yesIcon = new ImageIcon(ControllerPanel.class.getResource("/image/yes.png"));	
		JButton yesButton = new JButton(new ImageIcon(yesIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH)));
		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그아웃안내.png"));
		ImageIcon cancelImage = new ImageIcon(imageIcon.getImage().getScaledInstance(80, 80, Image.SCALE_SMOOTH));
			
		setButtonImage(yesButton);
		setButtonImage(noButton);
			
		label.setBounds(30, 20, 200, 100);
		yesButton.setBounds(30, 100, 80,80);
		noButton.setBounds(120, 100, 80,90);
		
		//passwordField.setBounds(30, 200, 80, 80); 
				
		add(yesButton);
		add(noButton);
		add(label);
		

		label.setFont(new Font("bold", Font.BOLD, 20));
		label.setForeground(Color.WHITE);	
		
		noButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e) { // 마우스클릭 		    	
		    	deleteFrame.setVisible(false);
		    }   
		}); 
		
		yesButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseClicked(MouseEvent e) { // 마우스클릭
		    	control.removeMember();
		    	deleteFrame.setVisible(false);
		    	controlPanel.setVisible(false);
		    	JOptionPane.showMessageDialog(null, "탈퇴되었습니다.", "안내메시지",  JOptionPane.QUESTION_MESSAGE, cancelImage);
		    }   
		}); 
		
		}
		
		public void paintComponent(Graphics g) {
			g.drawImage(deleteimage, 0, 0, null);
			setOpaque(false);
		}
		
	}
	
	

}
