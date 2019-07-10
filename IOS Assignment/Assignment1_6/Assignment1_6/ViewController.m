//
//  ViewController.m
//  Assignment1_6
//
//  Created by Subhradeep  on 3/20/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"

@interface ViewController () {
    NSUserDefaults *defaults;
    NSData *img;
}

@end

@implementation ViewController
@synthesize employeeIdLabel, employeeNameLabel, employeePositionLabel, addressLabel,maleBtn,femaleBtn,empId,empName,empPos,empAddress,empGender,imageDisplay;

- (void)viewDidLoad {
    [super viewDidLoad];
    
    self.empId = [[NSMutableArray alloc]init];
    self.empName = [[NSMutableArray alloc]init];
    self.empPos = [[NSMutableArray alloc]init];
    self.empAddress = [[NSMutableArray alloc]init];
    self.empGender = [[NSMutableArray alloc]init];
    
    defaults = [NSUserDefaults standardUserDefaults];
    
    UITapGestureRecognizer *tapped = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(imageFunc:)];
    [tapped setNumberOfTapsRequired: 1];
    [imageDisplay addGestureRecognizer:tapped];
}
	
- (IBAction)showButton:(id)sender {
    UIStoryboard *myStoryBoard = [UIStoryboard storyboardWithName:@"Main" bundle:nil ];
    UIViewController *VC = [myStoryBoard instantiateViewControllerWithIdentifier:@"ViewControllerSecond"];
    [self.navigationController pushViewController:VC animated:YES];
}

- (IBAction)maleButton:(id)sender {
    self.maleBtn.selected = !self.maleBtn.isSelected;
    
    if (self.maleBtn.isSelected)
    {
        self.femaleBtn.selected = NO;
    }
    else{
        self.maleBtn.selected = YES;
    }
}

- (IBAction)femaleButton:(id)sender {
    self.femaleBtn.selected = !self.femaleBtn.isSelected;
    
    if (self.femaleBtn.isSelected)
    {
        self.maleBtn.selected = NO;
    }
    else{
        self.femaleBtn.selected = YES;
    }
}

- (IBAction)addData:(id)sender {
    
    NSObject *obj = [defaults objectForKey:@"UserId"];
    
    if(obj == nil) {
       
        [empId addObject:employeeIdLabel.text];
        [empName addObject:employeeNameLabel.text];
        [empPos addObject:employeePositionLabel.text];
        [empAddress addObject:addressLabel.text];
    
        if(maleBtn.isSelected) {
            [empGender addObject:[maleBtn currentTitle]];
        } else if(femaleBtn.isSelected) {
            [empGender addObject:[femaleBtn currentTitle]];
        } else {
            [empGender addObject:[NSString stringWithFormat:@" "]];
        }
        
        NSArray *path = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
        NSString *documentsPath = [path objectAtIndex:0];
        
        NSString *filePath = [documentsPath stringByAppendingPathComponent: [NSString stringWithFormat:@"%@_%@.jpeg", employeeIdLabel.text, employeeNameLabel.text]];
        [img writeToFile:filePath atomically:YES];
        
    
        [defaults setObject:empId forKey:@"UserId"];
        [defaults setObject:empName forKey:@"UserName"];
        [defaults setObject:empPos forKey:@"UserPosition"];
        [defaults setObject:empGender forKey:@"UserGender"];
        [defaults setObject:empAddress forKey:@"UserAddress"];
    
        [defaults synchronize];
    
        employeeIdLabel.text = @" ";
        employeeNameLabel.text = @" ";
        employeePositionLabel.text = @" ";
        addressLabel.text = @" ";
        imageDisplay.image = nil;
        maleBtn.selected = NO;
        femaleBtn.selected = NO;
    }
    
    else {
        empId = [[defaults objectForKey:@"UserId"]mutableCopy];
        empName = [[defaults objectForKey:@"UserName"]mutableCopy];
        empPos = [[defaults objectForKey:@"UserPosition"]mutableCopy];
        empGender = [[defaults objectForKey:@"UserGender"]mutableCopy];
        empAddress = [[defaults objectForKey:@"UserAddress"]mutableCopy];
        
        [empId addObject:employeeIdLabel.text];
        [empName addObject:employeeNameLabel.text];
        [empPos addObject:employeePositionLabel.text];
        [empAddress addObject:addressLabel.text];
        
        if(maleBtn.isSelected) {
            [empGender addObject:[maleBtn currentTitle]];
        } else if(femaleBtn.isSelected) {
            [empGender addObject:[femaleBtn currentTitle]];
        } else {
            [empGender addObject:[NSString stringWithFormat:@" "]];
        }
        
        NSArray *path = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
        NSString *documentsPath = [path objectAtIndex:0];
        
        NSString *filePath = [documentsPath stringByAppendingPathComponent: [NSString stringWithFormat:@"%@_%@.jpeg", employeeIdLabel.text, employeeNameLabel.text]];
        [img writeToFile:filePath atomically:YES];
        
        [defaults setObject:empId forKey:@"UserId"];
        [defaults setObject:empName forKey:@"UserName"];
        [defaults setObject:empPos forKey:@"UserPosition"];
        [defaults setObject:empGender forKey:@"UserGender"];
        [defaults setObject:empAddress forKey:@"UserAddress"];
        
        [defaults synchronize];
        
        employeeIdLabel.text = @" ";
        employeeNameLabel.text = @" ";
        employeePositionLabel.text = @" ";
        addressLabel.text = @" ";
        imageDisplay.image = nil;
        maleBtn.selected = NO;
        femaleBtn.selected = NO;
    }
}

-(void)imageFunc:(UIGestureRecognizer *)recognizer {
    objController = [[UIImagePickerController alloc]init];
    objController.delegate = self;
    objController.sourceType = UIImagePickerControllerSourceTypeSavedPhotosAlbum;
    
    [self presentViewController:objController animated:YES completion:nil];
}

- (void)imagePickerController:(UIImagePickerController *)picker didFinishPickingMediaWithInfo:(NSDictionary *)info {
    imageDisplay.image = [info objectForKey:UIImagePickerControllerOriginalImage];
    [picker dismissViewControllerAnimated:YES completion:nil];
    img = UIImageJPEGRepresentation([info objectForKey:UIImagePickerControllerOriginalImage], 1);
}

- (void)imagePickerControllerDidCancel:(UIImagePickerController *)picker {
    [picker dismissViewControllerAnimated:YES completion:nil];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

@end
