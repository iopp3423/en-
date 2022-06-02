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
import javax.swing.JOptionPane;
import javax.swing.JPanel;

import utility.Constants;

public class ControllerPanel extends JPanel{

	private Image image;
	
	public ControllerPanel(editPanel edit) {
		
		
		ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/메뉴.png"));	
		image = new ImageIcon(imageIcon.getImage().getScaledInstance(1280, 720, Image.SCALE_SMOOTH)).getImage();
			
		setSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setPreferredSize(new Dimension(image.getWidth(null), image.getHeight(null)));
		setLayout(null);
		
		JButton editButton = new JButton(new ImageIcon(new ImageIcon("/image/edit.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		JButton setButton = new JButton(new ImageIcon(new ImageIcon("/image/set.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		JButton logoutButton = new JButton(new ImageIcon(new ImageIcon("/image/logout.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
		JButton deleteButton = new JButton(new ImageIcon(new ImageIcon("/image/delete.png").getImage().getScaledInstance(240, 400, Image.SCALE_SMOOTH)));
				
		setButtonImage(editButton);
		setButtonImage(setButton);
		setButtonImage(logoutButton);
		setButtonImage(deleteButton);
		
		editButton.setBounds(120, 57, 240, 400);
		setButton.setBounds(380, 57, 240, 400);
		logoutButton.setBounds(640, 57, 240, 400);
		deleteButton.setBounds(900, 57, 240, 400);
		
		add(editButton);
		add(setButton);
		add(logoutButton);
		add(deleteButton);
		
		
		
		editButton.addMouseListener(new MouseAdapter()  
		{  
		    public void mouseEntered(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		       
		    }

		    public void mouseExited(MouseEvent e) {
		        JButton button = (JButton)e.getSource();
		        
		    }
		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
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
		    	System.out.println("dddd");
		    }   
		}); 
		
		logoutButton.addMouseListener(new MouseAdapter()  
		{  
			
			public void mouseClicked(MouseEvent e)  
		    {  				
			
			ImageIcon imageIcon = new ImageIcon(MainPanel.class.getResource("/image/로그아웃안내.png"));
			ImageIcon logoutImage = new ImageIcon(imageIcon.getImage().getScaledInstance(50, 50, Image.SCALE_SMOOTH));
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
		    public void mousePressed(MouseEvent e) { // 마우스클릭 
		    	JButton button = (JButton)e.getSource();
		    	System.out.println("dddd");
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
	
}
