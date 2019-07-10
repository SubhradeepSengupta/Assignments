//
//  ViewController.h
//  Assignment1_6
//
//  Created by Subhradeep  on 3/20/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController <UIImagePickerControllerDelegate, UINavigationControllerDelegate> {
        UIImagePickerController *objController;
    }

@property (strong, nonatomic) IBOutlet UITextField *employeeIdLabel;
@property (strong, nonatomic) IBOutlet UITextField *employeeNameLabel;
@property (strong, nonatomic) IBOutlet UITextField *employeePositionLabel;
@property (strong, nonatomic) IBOutlet UITextView *addressLabel;
@property (strong, nonatomic) IBOutlet UIImageView *imageDisplay;

@property (strong, nonatomic) NSMutableArray *empId;
@property (strong, nonatomic) NSMutableArray *empName;
@property (strong, nonatomic) NSMutableArray *empPos;
@property (strong, nonatomic) NSMutableArray *empAddress;
@property (strong, nonatomic) NSMutableArray *empGender;


@property (strong, nonatomic) IBOutlet UIButton *maleBtn;
@property (strong, nonatomic) IBOutlet UIButton *femaleBtn;
- (IBAction)showButton:(id)sender;


- (IBAction)maleButton:(id)sender;
- (IBAction)femaleButton:(id)sender;
- (IBAction)addData:(id)sender;

@end

