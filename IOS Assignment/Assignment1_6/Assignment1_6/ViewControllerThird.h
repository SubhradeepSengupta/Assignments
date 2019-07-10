//
//  ViewControllerThird.h
//  Assignment1_6
//
//  Created by Subhradeep  on 3/22/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"

@interface ViewControllerThird : ViewController

@property (strong, nonatomic) IBOutlet UITextField *userIdLabel;
@property (strong, nonatomic) IBOutlet UITextField *userNameLabel;
@property (strong, nonatomic) IBOutlet UITextField *userPositionLabel;
@property (strong, nonatomic) IBOutlet UITextView *userAddressLabel;
@property (strong, nonatomic) IBOutlet UIImageView *imageDisplay;

@property (strong, nonatomic) IBOutlet UIButton *maleBtn;
@property (strong, nonatomic) IBOutlet UIButton *femaleBtn;

- (IBAction)buttonMale:(id)sender;
- (IBAction)buttonFemale:(id)sender;
- (IBAction)updateData:(id)sender;

@property (nonatomic) NSInteger index;
@property (strong, nonatomic) NSString *demoId;
@property (strong, nonatomic) NSString *demoName;
@property (strong, nonatomic) NSString *demoPosition;
@property (strong, nonatomic) NSString *demoAddress;
@property (strong, nonatomic) NSString *demoGender;

@property (strong, nonatomic) NSMutableArray *idArray;
@property (strong, nonatomic) NSMutableArray *nameArray;
@property (strong, nonatomic) NSMutableArray *positionArray;
@property (strong, nonatomic) NSMutableArray *genderArray;
@property (strong, nonatomic) NSMutableArray *addressArray;

@end
